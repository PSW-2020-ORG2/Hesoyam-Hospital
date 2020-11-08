using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Adapters;
using WebApplication.DTOs;
using Backend.Repository.MySQLRepository;
using Castle.Core.Internal;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        /// <summary>
        /// Creating feedback and storing it in database
        /// </summary>
        /// <param name="dto">Feedback to be created</param>
        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            return Ok(AppResources.getInstance().feedbackService.Create(FeedbackAdapter.newFeedbackDTOToFeedback(dto)));
        }
        
        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {
            IActionResult iResult;
            List<FeedbackDto> result = new List<FeedbackDto>();
            List<Feedback> feedbacks = AppResources.getInstance().feedbackService.GetAllUnpublished();
            if (feedbacks == null)
            {
                iResult = NotFound();
            }
            else
            {
                /*foreach (Feedback feedback in feedbacks)
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
                iResult = Ok(result);*/
            }
            return Ok(AppResources.getInstance().feedbackService.GetAllUnpublished());
        }

        [HttpGet("{id?}")] // GET /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            AppResources.getInstance().feedbackService.Publish(id);
            return Ok();
        }
    }
}
