using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
using Backend.Service.UsersService;
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
        [HttpGet("get-answers")]
        public IActionResult GetAllAnswers()
        {
            //List<Survey> surveys = AppResources.getInstance().surveyService.GetAll().ToList();

            //if (surveys == null) return NotFound();

            //return Ok(surveys.Select(survey => SurveyMapper.SurveyToSurveyDTO(survey)).ToArray());
            return Ok();

        }

    }
}
