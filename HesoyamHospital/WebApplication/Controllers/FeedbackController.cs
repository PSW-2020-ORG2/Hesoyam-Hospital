using System.Collections.Generic;
using Backend;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.DTOs;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (dto == null) return BadRequest();

            return Ok(AppResources.getInstance().feedbackService.Create(FeedbackAdapter.newFeedbackDTOToFeedback(dto)));
        }
        
        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            List<FeedbackDto> result = new List<FeedbackDto>();
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished();

            if (feedbacks == null) return NotFound();

            foreach (Feedback feedback in feedbacks)
            {
                result.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback));
            }

            return Ok(result.ToArray());
        }

        [HttpGet("published")]  //GET /api/feedback/published
        public IActionResult GetPublishedFeedbacks()
        {
            List<FeedbackDto> result = new List<FeedbackDto>();
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllPublished();

            if (feedbacks == null) return NotFound();

            foreach (Feedback feedback in feedbacks)
            {
                result.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback));
            }

            return Ok(result.ToArray());
        }

        [HttpGet("{id?}")] // GET /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
