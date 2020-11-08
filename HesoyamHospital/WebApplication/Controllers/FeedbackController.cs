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

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(NewFeedbackDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            AppResources.getInstance().feedbackService.Create(FeedbackAdapter.newFeedbackDTOToFeedback(dto));
            return Ok();
        }
    }
}
