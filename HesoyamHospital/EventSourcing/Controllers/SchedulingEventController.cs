using EventSourcing.Model.Scheduling;
using EventSourcing.Repository;
using EventSourcing.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingEventController : ControllerBase
    {
        private readonly EventDbContext eventDbContext;
        private readonly ISchedulingAnalysis schedulingAnalysis;

        public SchedulingEventController(EventDbContext eventDbContext, ISchedulingAnalysis schedulingAnalysis)
        {
            this.eventDbContext = eventDbContext;
            this.schedulingAnalysis = schedulingAnalysis;
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

        [HttpGet("percentage-of-successful")]
        public IActionResult GetPercentageOfSuccessfullyScheduledAppointments()
        {
            try
            {
                return Ok(schedulingAnalysis.GetPercentageOfSuccessfullyScheduledAppointments());
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("percentage-of-going-back-by-step")]
        public IActionResult GetPercentageOfReturningBackByStep()
            => Ok(schedulingAnalysis.GetPercentageOfReturningBackByStep());

        [HttpGet("mean-value-of-steps-per-scheduling")]
        public IActionResult GetMeanValueOfStepsPerScheduling()
            => Ok(schedulingAnalysis.GetMeanValueOfStepsPerScheduling());

        [HttpGet("mean-value-of-back-steps-per-scheduling")]
        public IActionResult GetMeanValueOfBackStepsPerScheduling()
            => Ok(schedulingAnalysis.GetMeanValueOfBackStepsPerScheduling());

        [HttpGet("percantage-of-quitting-by-step")]
        public IActionResult GetPercentageOfQuittingSchedulingByStep()
            => Ok(GetPercentageOfQuittingSchedulingByStep());
    }
}
