using EventSourcing.Model.Scheduling;
using System.Collections.Generic;
using System.Linq;

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
            => eventDbContext.SchedulingStartedEvents.OrderBy(e => e.Timestamp);

        public IEnumerable<SchedulingStepChangedEvent> GetSchedulingStepChangedEvents()
            => eventDbContext.SchedulingStepChangedEvents.OrderBy(e => e.Timestamp);

        public IEnumerable<SchedulingEndedEvent> GetSchedulingEndedEvents()
            => eventDbContext.SchedulingEndedEvents.OrderBy(e => e.Timestamp);
    }
}
