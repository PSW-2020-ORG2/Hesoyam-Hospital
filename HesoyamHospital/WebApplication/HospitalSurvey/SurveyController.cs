using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication.HospitalSurvey;

namespace WebApplication.HospitalSurvey
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        [HttpPost("send-answers")]
        public IActionResult SendAnswersOfSurvey([FromBody] SurveyDTO dto)
        {
            if (!SurveyValidation.isNewSurveyValid(dto)) return BadRequest();
            AppResources.getInstance().surveyService.Create(SurveyMapper.SurveyDTOToSurvey(dto));
            return Ok();
        }
       
    }
}
