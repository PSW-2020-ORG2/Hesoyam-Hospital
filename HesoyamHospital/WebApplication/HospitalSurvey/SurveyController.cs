using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult SimpleSearchDocs([FromBody] SurveyDTO criteria)
        {
            throw new NotImplementedException();
        }
    }
}
