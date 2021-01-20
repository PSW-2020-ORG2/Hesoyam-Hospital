using EventSourcing.Model.Scheduling;
using EventSourcing.Repository;
using EventSourcing.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WebApplicationTests.Unit.Scheduling
{
    public class SchedulingProcessAnalysisTests
    {
        [Fact]
        public void Get_percentage_of_successfully_scheduled_appointments()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double percentage = service.GetPercentageOfSuccessfullyScheduledAppointments();

            percentage.ShouldBe(50);
        }

        [Fact]
        public void Get_percentage_of_going_back_by_step()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            Dictionary<int, double> res = service.GetPercentageOfReturningBackByStep();

            res[1].ShouldBe(100);
            res.ContainsKey(0).ShouldBe(false);
            res.ContainsKey(2).ShouldBe(false);
            res.ContainsKey(3).ShouldBe(false);
        }

        [Fact]
        public void Get_average_number_of_steps_per_scheduling()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double averageNumberOfSteps = service.GetMeanValueOfStepsPerScheduling();

            averageNumberOfSteps.ShouldBe(5);
        }

        [Fact]
        public void Get_average_number_of_back_steps_per_scheduling()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double averageNumberOfBackSteps = service.GetMeanValueOfBackStepsPerScheduling();

            averageNumberOfBackSteps.ShouldBe(0.5);
        }

        [Fact]
        public void Get_percentage_of_quitting_by_step()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            Dictionary<int, double> res = service.GetPercentageOfQuittingSchedulingByStep();

            res.ContainsKey(0).ShouldBe(false);
            res.ContainsKey(1).ShouldBe(false);
            res.ContainsKey(2).ShouldBe(false);
            res[3].ShouldBe(100);
        }

        [Fact]
        public void Get_average_time_needed_for_scheduling()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double averageTime = service.GetAverageTimeForScheduling();

            averageTime.ShouldBe(50);
        }

        [Fact]
        public void Get_average_time_needed_for_successful_scheduling()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double averageTime = service.GetAverageTimeForSuccessfulScheduling();

            averageTime.ShouldBe(40);
        }

        [Fact]
        public void Get_average_time_needed_for_unsuccessful_scheduling()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            double averageTime = service.GetAverageTimeForUnsuccessfulScheduling();

            averageTime.ShouldBe(60);
        }

        [Fact]
        public void Get_average_time_needed_for_each_step()
        {
            SchedulingAnalysis service = new SchedulingAnalysis(CreateStubRepository());

            Dictionary<int, double> res = service.GetMeanValueOfTimeSpentByStep();

            res[0].ShouldBe(10);
            res[1].ShouldBe(15);
            res[2].ShouldBe(15);
            res[3].ShouldBe(10);
        }

        private static ISchedulingEventsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ISchedulingEventsRepository>();
            var startEvents = new List<SchedulingStartedEvent>();
            var endEvents = new List<SchedulingEndedEvent>();
            var stepChangedEvents = new List<SchedulingStepChangedEvent>();

            DateTime baseTimestamp = new DateTime(2020, 12, 10);

            startEvents.Add(new SchedulingStartedEvent(baseTimestamp.AddSeconds(-60), "pera"));
            startEvents.Add(new SchedulingStartedEvent(baseTimestamp.AddSeconds(-60), "mika"));

            endEvents.Add(new SchedulingEndedEvent(baseTimestamp.AddSeconds(-20), "pera", SchedulingOutcome.SUCCESSFUL));
            endEvents.Add(new SchedulingEndedEvent(baseTimestamp, "mika", SchedulingOutcome.UNSUCCESSFUL));

            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-50), "pera", Step.FORWARD, 1));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-40), "pera", Step.FORWARD, 2));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-30), "pera", Step.FORWARD, 3));

            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-50), "mika", Step.FORWARD, 1));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-40), "mika", Step.FORWARD, 2));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-30), "mika", Step.BACKWARD, 1));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-20), "mika", Step.FORWARD, 2));
            stepChangedEvents.Add(new SchedulingStepChangedEvent(baseTimestamp.AddSeconds(-10), "mika", Step.FORWARD, 3));

            stubRepository.Setup(r => r.GetSchedulingStartedEvents()).Returns(startEvents.OrderBy(e => e.Timestamp));
            stubRepository.Setup(r => r.GetSchedulingEndedEvents()).Returns(endEvents.OrderBy(e => e.Timestamp));
            stubRepository.Setup(r => r.GetSchedulingStepChangedEvents()).Returns(stepChangedEvents.OrderBy(e => e.Timestamp));
            return stubRepository.Object;
        }
    }
}
