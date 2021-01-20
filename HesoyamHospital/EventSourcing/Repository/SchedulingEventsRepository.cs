using EventSourcing.Model.Scheduling;
using System.Collections.Generic;

namespace EventSourcing.Repository
{
    public class SchedulingEventsRepository : ISchedulingEventsRepository
    {
        private readonly EventDbContext eventDbContext;
        public SchedulingEventsRepository(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        public IEnumerable<SchedulingStartedEvent> GetSchedulingStartedEvents()
            => eventDbContext.SchedulingStartedEvents;

        public IEnumerable<SchedulingStepChangedEvent> GetSchedulingStepChangedEvents()
            => eventDbContext.SchedulingStepChangedEvents;

        public IEnumerable<SchedulingEndedEvent> GetSchedulingEndedEvents()
            => eventDbContext.SchedulingEndedEvents;
    }
}
