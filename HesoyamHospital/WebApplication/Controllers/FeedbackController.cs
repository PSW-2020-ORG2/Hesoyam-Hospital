using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.Dtos;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            List<FeedbackDto> result = new List<FeedbackDto>();
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished().ToList();
            foreach(Feedback feedback in feedbacks)
            {
                result.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback));
            }
            return Ok(result);
        }

        [HttpGet("{id?}")] // GET /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
