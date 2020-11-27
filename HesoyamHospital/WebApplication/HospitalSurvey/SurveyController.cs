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
            if (!SurveyValidation.IsNewSurveyValid(dto)) return BadRequest();
           
            AppResources.getInstance().surveyService.Create(SurveyMapper.SurveyDTOToSurvey(dto));
            
            return Ok();
        }
        [HttpGet("get-answers")]
        public IActionResult GetAllAnswers()
        {
            List<Survey> surveys = AppResources.getInstance().surveyService.GetAll().ToList();

            if (surveys == null) return NotFound();

            return Ok(surveys.Select(survey => SurveyMapper.SurveyToSurveyDTO(survey)).ToArray());
            

        }
        [HttpGet("mean-value-per-section/{section}")]
        public IActionResult MeanValuePerSection(string section)
        {
            if(section=="Doctor")
            {
              return Ok(AppResources.getInstance().surveyService.MeanValuesPerDoctorSection());
            }
            else if (section == "Staff")
            {
              return Ok(AppResources.getInstance().surveyService.MeanValuesPerStaffSection());
            }
            else if(section=="Hygiene")
            {
              return Ok(AppResources.getInstance().surveyService.MeanValuesPerHygieneSection());
            }
            else if(section == "Equipment")
            {
              return Ok(AppResources.getInstance().surveyService.MeanValuesPerEquipmentSection());
            }else
            {
                return BadRequest();
            }
           
        }
        [HttpGet("mean-value-per-question/{section}")]
        public IActionResult MeanValuePerQuestion(string section)
        {
            if (section == "Doctor")
            {
                return Ok(AppResources.getInstance().surveyService.MeanValuesPerDoctorQuestions());
            }
            else if (section == "Staff")
            {
                return Ok(AppResources.getInstance().surveyService.MeanValuesPerStaffQuestions());
            }
            else if (section == "Hygiene")
            {
                return Ok(AppResources.getInstance().surveyService.MeanValuesPerHygieneQuestions());
            }
            else if (section == "Equipment")
            {
                return Ok(AppResources.getInstance().surveyService.MeanValuesPerEquipmentQuestions());
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("frequencies-per-question/{section}")]
        public IActionResult FrequenciesPerQuestion(string section)
        {
            if (section == "Doctor")
            {
                return Ok(AppResources.getInstance().surveyService.FrequencyPerDoctorQuestions());
            }
            else if (section == "Staff")
            {
                return Ok(AppResources.getInstance().surveyService.FrequencyPerStaffQuestions());
            }
            else if (section == "Hygiene")
            {
                return Ok(AppResources.getInstance().surveyService.FrequencyPerHygieneQuestions());
            }
            else if (section == "Equipment")
            {
                return Ok(AppResources.getInstance().surveyService.FrequencyPerEquipmentQuestions());
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("answers-per-doctors/{id}")]
        public IActionResult AnswersPerDoctors(long id)
        {
            Doctor doctor = AppResources.getInstance().doctorService.GetByID(id);
            List<Section> sections = AppResources.getInstance().surveyService.GetSurveysPerDoctors(doctor);


            if (doctor == null)
            {
                return BadRequest();
            }
            return Ok(sections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());
        }

        [HttpGet("average-grade-per-doctor/{id}")]
        public IActionResult AveragreGradePerDoctor(long id)
        {
            Doctor doctor = AppResources.getInstance().doctorService.GetByID(id);
            
            if (doctor == null)
            {
                return BadRequest();
            }
            return Ok(AppResources.getInstance().surveyService.GetAvarageGradePerDoctors(doctor));

        }

        [HttpGet("getAllDoctors")]
        public IActionResult AllDoctors()
        {
            List<Doctor> doctors = AppResources.getInstance().doctorService.GetAll().ToList();
            if(doctors == null)
            {
                return BadRequest();
            }
            return Ok(doctors.Select(doctor => DoctorMapper.DoctorToDoctorDTO(doctor)).ToArray());

        }
    }
}
