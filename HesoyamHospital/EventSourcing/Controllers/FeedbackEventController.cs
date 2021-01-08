using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSourcing.Model.Feedback;
using EventSourcing.Repository;

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackEventController : Controller
    {
        private readonly EventDbContext eventDbContext;

        public FeedbackEventController(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        [HttpPost("createFeedbackEvent")]
        public IActionResult createFeedbackCreatedEvent([FromBody] FeedbackCreatedEvent feedbackCreatedEvent)
        {
            eventDbContext.FeedbackCreatedEvents.Add(feedbackCreatedEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("getFeedbackEvent/{id}")]
        public IActionResult getFeedbackCreatedEvent(long id)
        {
            FeedbackCreatedEvent feedbackCreatedEvent = eventDbContext.FeedbackCreatedEvents.FirstOrDefault(feedbackCreatedEvent => feedbackCreatedEvent.Id == id);

            if (feedbackCreatedEvent == null) return NotFound();

            return Ok(feedbackCreatedEvent);
        }

        [HttpPost("createSurveyAnsweredEvent")]
        public IActionResult createSurveyAnsweredEvent([FromBody] SurveyAnsweredEvent surveyAnsweredEvent)
        {
            eventDbContext.SurveyAnsweredEvents.Add(surveyAnsweredEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("getSurveyAnsweredEvent/{id}")]
        public IActionResult getSurveyAnsweredEvent(long id)
        {

            SurveyAnsweredEvent surveyAnsweredEvent = eventDbContext.SurveyAnsweredEvents.FirstOrDefault(surveyAnsweredEvent => surveyAnsweredEvent.Id == id);
            if (surveyAnsweredEvent == null) return NotFound();

            return Ok(surveyAnsweredEvent);
        }

    }
}
