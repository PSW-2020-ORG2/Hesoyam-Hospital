using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository;
using Castle.Core.Internal;
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
            IActionResult iResult;
            List<FeedbackDto> result = new List<FeedbackDto>();
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished().ToList();
            if (feedbacks == null)
            {
                iResult = NotFound();
            }
            else
            {
                foreach (Feedback feedback in feedbacks)
                {
                    result.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback));
                    
                }
                FeedbackDto f = new FeedbackDto();
                f.Id = 100;
                f.Anonymous = true;
                f.UserName = "Anonymous";
                f.Published = false;
                f.Comment = "Nice.";
                f.Public = true;
                result.Add(f);
                iResult = Ok(result);
            }
            return iResult;
        }

        [HttpGet("{id?}")] // GET /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
