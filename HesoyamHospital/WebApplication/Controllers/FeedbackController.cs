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
        private readonly MyDbContext dbContext;
        public FeedbackController(MyDbContext context)
        {
            this.dbContext = context;
        }


        [HttpGet("unpublished")]  //GET /api/feedback/unpublished
        public IActionResult GetUnpublishedFeedbacks()
        {

            List<FeedbackDto> result =new  List<FeedbackDto>();
            List<Feedback> allFeedbacks = AppResources.getInstance().feedbackService.GetAll().ToList();
            foreach(Feedback feedback in allFeedbacks)
            {
                if (feedback.Published == false)
                {
                    result.Add(FeedbackAdapter.FeedbackToFeedbackDto(feedback));
                }
            }
            
            return Ok(result);
        }
        [HttpGet("{id?}")] // PUT /api/feedback/123
        public IActionResult PublishFeedback(long id)
        {
            Feedback feedback = AppResources.getInstance().feedbackService.GetAll().ToList().SingleOrDefault(feedback => feedback.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                feedback.Published = true;
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
