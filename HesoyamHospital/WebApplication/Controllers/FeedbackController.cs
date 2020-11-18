using System.Collections.Generic;
using Backend;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.DTOs;
using System.Linq;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Status()
        {
            return Ok("Feedback controller is up and running");
        }

        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (dto == null) return BadRequest();

            return Ok(AppResources.getInstance().feedbackService.Create(FeedbackAdapter.NewFeedbackDTOToFeedback(dto)));
        }
        
        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackAdapter.FeedbackToFeedbackDto(feedback)).ToArray());

        }

        [HttpGet("published")]  //GET /api/feedback/published
        public IActionResult GetPublishedFeedbacks()
        {
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllPublished();

            if (feedbacks == null) return NotFound();

            return Ok(feedbacks.Select(feedback => FeedbackAdapter.FeedbackToFeedbackDto(feedback)).ToArray());
        }

        [HttpGet("{id?}")] // GET /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
