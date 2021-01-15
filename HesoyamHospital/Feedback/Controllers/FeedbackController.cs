using System.Collections.Generic;
using System.Linq;
using Feedbacks.Model;
using Feedbacks.DTOs;
using Feedbacks.Mappers;
using Feedbacks.Service.Abstract;
using Feedbacks.Validation;
using Microsoft.AspNetCore.Mvc;
using EventSourceClasses;
using EventSourceClasses.Feedback;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly EventLogger _feedbackLogger;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
            _feedbackLogger = new EventLogger();
        }

        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (!FeedbackValidation.IsNewFeedbackValid(dto)) return BadRequest();
            _feedbackService.Create(FeedbackMapper.NewFeedbackDTOToFeedback(dto));
            _feedbackLogger.log(new FeedbackCreatedEvent(dto.Comment, dto.Anonymous, dto.Public, dto.Username));
            return Ok();
        }

        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            List<Feedback> feedbacks = _feedbackService.GetAllUnpublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackMapper.FeedbackToFeedbackDto(feedback)).ToArray());

        }

        [HttpGet("published")]  //GET /api/feedback/published
        public IActionResult GetPublishedFeedbacks()
        {
            List<Feedback> feedbacks = _feedbackService.GetAllPublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackMapper.FeedbackToFeedbackDto(feedback)).ToArray());
        }

        [HttpPut]
        public IActionResult PublishFeedback([FromBody] long id)
        {
            _feedbackService.Publish(id);
            return Ok();
        }
    }
}
