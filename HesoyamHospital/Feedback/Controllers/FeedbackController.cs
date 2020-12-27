using System.Collections.Generic;
using System.Linq;
using Authentication.Model.FeedbackModel;
using Feedbacks.DTOs;
using Feedbacks.Mappers;
using Feedbacks.Service.Abstract;
using Feedbacks.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (!FeedbackValidation.IsNewFeedbackValid(dto)) return BadRequest();
            _feedbackService.Create(FeedbackMapper.NewFeedbackDTOToFeedback(dto));
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
