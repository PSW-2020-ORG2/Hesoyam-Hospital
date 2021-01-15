using EventSourcing.Model.Scheduling;
using EventSourcing.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingEventController : ControllerBase
    {
        private readonly EventDbContext eventDbContext;

        public SchedulingEventController(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        [HttpPost("create/start")]
        public IActionResult Create([FromBody] SchedulingStartedEvent schedulingStartedEvent)
        {
            eventDbContext.SchedulingStartedEvents.Add(schedulingStartedEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("create/end")]
        public IActionResult Create([FromBody] SchedulingEndedEvent schedulingEndedEvent)
        {
            eventDbContext.SchedulingEndedEvents.Add(schedulingEndedEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("create/step-changed")]
        public IActionResult Create([FromBody] SchedulingStepChangedEvent schedulingStepChangedEvent)
        {
            eventDbContext.SchedulingStepChangedEvents.Add(schedulingStepChangedEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }
    }
}
