using EventSourcing.Model.Scheduling;
using EventSourcing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcing.Service
{
    public class SchedulingAnalysis : ISchedulingAnalysis
    {
        private readonly EventDbContext _dbContext;
        public SchedulingAnalysis(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dictionary<int, double> GetMeanValueOfTimeSpentByStep()
        {
            Dictionary<int, double> meanValues = GetSumOfTimesSpentByStep();
            foreach (int key in meanValues.Keys.ToList())
                if (key == 0) meanValues[key] = meanValues[key] / _dbContext.SchedulingStartedEvents.Count();
                else meanValues[key] = meanValues[key] / _dbContext.SchedulingStepChangedEvents.Count(u => u.CurrentStep == key);
            return meanValues;
        }

        public double GetAverageTimeForScheduling()
        {
            IEnumerable<SchedulingStartedEvent> startEvents = _dbContext.SchedulingStartedEvents.ToList();
            double durationSum = 0;
            foreach (SchedulingStartedEvent startEvent in startEvents)
                durationSum += (GetEndOfSchedulingEvent(startEvent).Timestamp - startEvent.Timestamp).Seconds; 
            return durationSum / startEvents.Count();
        }

        public double GetAverageTimeForSuccessfulScheduling()
        {
            IEnumerable<SchedulingStartedEvent> startEvents = _dbContext.SchedulingStartedEvents.ToList();
            double durationSum = 0;
            double successfulCount = 0;
            foreach (SchedulingStartedEvent startEvent in startEvents)
                if(GetEndOfSchedulingEvent(startEvent).Outcome == SchedulingOutcome.SUCCESSFUL)
                {
                    successfulCount++;
                    durationSum += (GetEndOfSchedulingEvent(startEvent).Timestamp - startEvent.Timestamp).Seconds;
                }
            return durationSum / successfulCount;
        }

        public double GetAverageTimeForUnsuccessfulScheduling()
        {
            IEnumerable<SchedulingStartedEvent> startEvents = _dbContext.SchedulingStartedEvents.ToList();
            double durationSum = 0;
            double unsuccessfulCount = 0;
            foreach (SchedulingStartedEvent startEvent in startEvents)
                if (GetEndOfSchedulingEvent(startEvent).Outcome == SchedulingOutcome.UNSUCCESSFUL)
                {
                    unsuccessfulCount++;
                    durationSum += (GetEndOfSchedulingEvent(startEvent).Timestamp - startEvent.Timestamp).Seconds;
                }
            return durationSum / unsuccessfulCount;
        }

        public double GetPercentageOfSuccessfullyScheduledAppointments()
        {
            if (_dbContext.SchedulingEndedEvents.Count() == 0) throw new Exception("No data to be processed!");
            return (double)_dbContext.SchedulingEndedEvents.Count(e => e.Outcome == SchedulingOutcome.SUCCESSFUL) / _dbContext.SchedulingEndedEvents.Count() * 100;
        }

        public Dictionary<int, double> GetPercentageOfReturningBackByStep()
        {
            Dictionary<int, double> res = new Dictionary<int, double>();
            foreach(int step in GetAllStepsBackwards().Select(step => step.CurrentStep).Distinct())
                res[step] = (double)GetAllStepsBackwards().Count(s => s.CurrentStep == step) / GetAllStepsBackwards().Count() * 100;
            return res;
        }

        public double GetMeanValueOfBackStepsPerScheduling()
        {
            IEnumerable<IEnumerable<SchedulingStepChangedEvent>> schedulingSequences = GetAllSchedulingSequences();
            if (schedulingSequences.Count() == 0) return 0;
            int backStepCountForFinishedSchedulings = 0;
            foreach (IEnumerable<SchedulingStepChangedEvent> schedulingSequence in schedulingSequences)
                backStepCountForFinishedSchedulings += schedulingSequence.Count(s => s.StepType == Step.BACKWARD);
            return (double)backStepCountForFinishedSchedulings / schedulingSequences.Count();
        }

        public double GetMeanValueOfStepsPerScheduling()
            => GetMeanValueOfBackStepsPerScheduling() + _dbContext.SchedulingStepChangedEvents.Select(step => step.CurrentStep).Distinct().Count();

        public Dictionary<int, double> GetPercentageOfQuittingSchedulingByStep()
        {
            Dictionary<int, double> res = new Dictionary<int, double>();
            IEnumerable<IEnumerable<SchedulingStepChangedEvent>> schedulingSequences = GetAllUnsuccessfulSchedulingSequences();
            foreach (IEnumerable<SchedulingStepChangedEvent> schedulingSequence in schedulingSequences)
                if (schedulingSequence.Any())
                {
                    if (res.ContainsKey(schedulingSequence.Last().CurrentStep)) res[schedulingSequence.Last().CurrentStep] += 1;
                    else res[schedulingSequence.Last().CurrentStep] = 1;
                }
                else
                {
                    if (res.ContainsKey(0)) res[0] += 1;
                    else res[0] = 1;
                }
            foreach (int key in res.Keys.ToList())
                res[key] = res[key] / schedulingSequences.Count() * 100;
            return res;
        }

        private IEnumerable<IEnumerable<SchedulingStepChangedEvent>> GetAllSchedulingSequences()
        {
            IEnumerable<IEnumerable<SchedulingStepChangedEvent>> res = new List<List<SchedulingStepChangedEvent>>();
            IEnumerable<SchedulingStartedEvent> schedulingStartedEvents = _dbContext.SchedulingStartedEvents.ToList();
            foreach (SchedulingStartedEvent schedulingStarted in schedulingStartedEvents)
                res = res.Append(GetASchedulingSequence(schedulingStarted));
            return res;
        }

        private IEnumerable<IEnumerable<SchedulingStepChangedEvent>> GetAllUnsuccessfulSchedulingSequences()
        {
            IEnumerable<IEnumerable<SchedulingStepChangedEvent>> res = new List<List<SchedulingStepChangedEvent>>();
            IEnumerable<SchedulingStartedEvent> schedulingStartedEvents = _dbContext.SchedulingStartedEvents.ToList();
            foreach (SchedulingStartedEvent schedulingStarted in schedulingStartedEvents)
                if (GetEndOfSchedulingEvent(schedulingStarted).Outcome == SchedulingOutcome.UNSUCCESSFUL)
                    res = res.Append(GetASchedulingSequence(schedulingStarted));
            return res;
        }

        private IEnumerable<SchedulingStepChangedEvent> GetASchedulingSequence(SchedulingStartedEvent schedulingStarted)
        {
            SchedulingEndedEvent schedulingEnded = GetEndOfSchedulingEvent(schedulingStarted);
            return _dbContext.SchedulingStepChangedEvents.Where(step => step.PatientUsername.Equals(schedulingStarted.PatientUsername)
            && step.PatientUsername.Equals(schedulingEnded.PatientUsername)
            && step.Timestamp > schedulingStarted.Timestamp
            && step.Timestamp < schedulingEnded.Timestamp);
        }

        private SchedulingEndedEvent GetEndOfSchedulingEvent(SchedulingStartedEvent schedulingStarted)
            => _dbContext.SchedulingEndedEvents.Where(e => e.PatientUsername.Equals(schedulingStarted.PatientUsername)
                && e.Timestamp > schedulingStarted.Timestamp)
                .OrderBy(e => e.Timestamp).FirstOrDefault();

        private IEnumerable<SchedulingStepChangedEvent> GetAllStepsBackwards()
            => _dbContext.SchedulingStepChangedEvents.Where(e => e.StepType == Step.BACKWARD).ToList();


        private Dictionary<int, double> GetSumOfTimesSpentByStep()
        {
            IEnumerable<SchedulingStartedEvent> startEvents = _dbContext.SchedulingStartedEvents.ToList();
            Dictionary<int, double> meanValues = new Dictionary<int, double>();
            foreach (SchedulingStartedEvent startEvent in startEvents)
                if (GetASchedulingSequence(startEvent).Any())
                {
                    meanValues = GetSumOfTimesSpentForEventByStep(meanValues, startEvent);
                } else{
                    meanValues.TryGetValue(0, out double endEventCount);
                    meanValues[0] = endEventCount + (GetEndOfSchedulingEvent(startEvent).Timestamp - startEvent.Timestamp).Seconds;
                }
            return meanValues;
        }

        private Dictionary<int, double> GetSumOfTimesSpentForEventByStep(Dictionary<int, double> meanValues, SchedulingStartedEvent startEvent)
        {
            SchedulingEndedEvent endEvent = GetEndOfSchedulingEvent(startEvent);
            List<SchedulingStepChangedEvent> changedSteps = GetASchedulingSequence(startEvent).ToList();
            meanValues.TryGetValue(0, out double startEventCount);
            meanValues[0] = startEventCount + (changedSteps[0].Timestamp - startEvent.Timestamp).Seconds;
            for (int i = 0; i < changedSteps.Count() - 1; i++)
            {
                meanValues.TryGetValue(changedSteps[i].CurrentStep, out double currentCount);
                meanValues[changedSteps[i].CurrentStep] = currentCount + (changedSteps[i + 1].Timestamp - changedSteps[i].Timestamp).Seconds;
            }
            meanValues.TryGetValue(changedSteps.Last().CurrentStep, out double endEventCount);
            meanValues[changedSteps.Last().CurrentStep] = endEventCount + (endEvent.Timestamp - changedSteps.Last().Timestamp).Seconds;
            return meanValues;
        }
    }
}
