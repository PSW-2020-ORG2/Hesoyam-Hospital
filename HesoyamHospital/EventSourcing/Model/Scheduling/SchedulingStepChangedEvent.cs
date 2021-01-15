using System;

namespace EventSourcing.Model.Scheduling
{
    public class SchedulingStepChangedEvent
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string PatientUsername { get; set; }
        public Step StepType { get; set; }
        public int CurrentStep { get; set; }

        public SchedulingStepChangedEvent() { }

        public SchedulingStepChangedEvent(DateTime timestamp, string patientUsername, Step stepType, int currentStep)
        {
            Timestamp = timestamp;
            PatientUsername = patientUsername;
            StepType = stepType;
            CurrentStep = currentStep;
        }
    }
}
