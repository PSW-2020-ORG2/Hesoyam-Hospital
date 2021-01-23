using EventSourcing.Model.Scheduling;
using System;
using System.Collections.Generic;

namespace EventSourcing.Repository
{
    public interface ISchedulingEventsRepository
    {
        public IEnumerable<SchedulingStartedEvent> GetSchedulingStartedEvents();
        public IEnumerable<SchedulingStepChangedEvent> GetSchedulingStepChangedEvents();
        public IEnumerable<SchedulingEndedEvent> GetSchedulingEndedEvents();
    }
}
