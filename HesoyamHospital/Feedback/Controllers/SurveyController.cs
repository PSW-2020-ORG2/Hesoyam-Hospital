using System.Collections.Generic;
using System.Linq;
using Feedbacks.Model;
using Feedbacks.DTOs;
using Feedbacks.Mappers;
using Feedbacks.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Feedbacks.Validation;
using System.Net.Http;
using Feedbacks.Service;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly IHttpRequestSender _requestSender;

        public SurveyController(ISurveyService surveyService, IHttpClientFactory clientFactory)
        {
            _surveyService = surveyService;
            _requestSender = new HttpRequestSender(clientFactory);
        }

        [HttpPost("send-answers/{appointmentId}")]
        public IActionResult SendAnswersOfSurvey([FromBody] SurveyDTO dto, long appointmentId)
        {
            if (!_requestSender.GetAbleToFillOutSurvey(appointmentId) || !SurveyValidation.IsNewSurveyValid(dto)) return BadRequest();
            _surveyService.FillOutSurvey(_requestSender, dto, appointmentId);
            return Ok();
        }

        [HttpGet("get-answers")]
        public IActionResult GetAllAnswers()
        {
            List<Survey> surveys = _surveyService.GetAll().ToList();
            if (surveys == null) return NotFound();
            return Ok(surveys.Select(survey => SurveyMapper.SurveyToSurveyDTO(survey)).ToArray());
        }

        [HttpGet("get-answers-per-section/{section}")]
        public IActionResult GetAnswersPerSections(string section)
        {
            List<Section> doctorSections = _surveyService.GetAnswersPerDoctorSections();
            List<Section> staffSections = _surveyService.GetAnswersPerStaffSections();
            List<Section> hygieneSections = _surveyService.GetAnswersPerHygieneSections();
            List<Section> equipmentSections = _surveyService.GetAnswersPerEquipmentSections();

            if (section == "Doctor")
            {
                return Ok(doctorSections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());
            }
            else if (section == "Staff")
            {
                return Ok(staffSections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());

            }
            else if (section == "Hygiene")
            {
                return Ok(hygieneSections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());

            }
            else if (section == "Equipment")
            {
                return Ok(equipmentSections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());

            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("mean-value-per-section")]
        public IActionResult MeanValuePerSection()
        {
            List<double> means = new List<double>
            {
                _surveyService.MeanValuesPerDoctorSection(),
                _surveyService.MeanValuesPerStaffSection(),
                _surveyService.MeanValuesPerHygieneSection(),
                _surveyService.MeanValuesPerEquipmentSection()
            };

            List<MeanDTO> result = new List<MeanDTO>();
            MeanDTO dto = new MeanDTO(means[0], means[1], means[2], means[3]);
            result.Add(dto);
            return Ok(result.ToArray());
        }

        [HttpGet("mean-value-per-question/{section}")]
        public IActionResult MeanValuePerQuestion(string section)
        {
            List<double> meanArrayDoctor = _surveyService.MeanValuesPerDoctorQuestions();
            List<double> meanArrayStaff = _surveyService.MeanValuesPerStaffQuestions();
            List<double> meanArrayHygiene = _surveyService.MeanValuesPerHygieneQuestions();
            List<double> meanArrayEquipment = _surveyService.MeanValuesPerEquipmentQuestions();
            List<MeanDTO> means = new List<MeanDTO>();
            List<MeanDTO> means2 = new List<MeanDTO>();
            List<MeanDTO> means3 = new List<MeanDTO>();
            List<MeanDTO> means4 = new List<MeanDTO>();
            MeanDTO dto = new MeanDTO(meanArrayDoctor[0], meanArrayDoctor[1], meanArrayDoctor[2], meanArrayDoctor[3]);
            MeanDTO dto2 = new MeanDTO(meanArrayStaff[0], meanArrayStaff[1], meanArrayStaff[2], meanArrayDoctor[3]);
            MeanDTO dto3 = new MeanDTO(meanArrayHygiene[0], meanArrayHygiene[1], meanArrayHygiene[2], meanArrayHygiene[3]);
            MeanDTO dto4 = new MeanDTO(meanArrayEquipment[0], meanArrayEquipment[1], meanArrayEquipment[2], meanArrayEquipment[3]);

            means.Add(dto);
            means2.Add(dto2);
            means3.Add(dto3);
            means4.Add(dto4);

            if (section == "Doctor")
            {
                return Ok(means.ToArray());
            }
            else if (section == "Staff")
            {
                return Ok(means2.ToArray());
            }
            else if (section == "Hygiene")
            {
                return Ok(means3.ToArray());
            }
            else if (section == "Equipment")
            {
                return Ok(means4.ToArray());
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("frequencies-per-question/{section}")]
        public IActionResult FrequenciesPerQuestion(string section)
        {
            return section switch
            {
                "Doctor" => Ok(_surveyService.FrequencyPerDoctorQuestions().Values),
                "Staff" => Ok(_surveyService.FrequencyPerStaffQuestions().Values),
                "Hygiene" => Ok(_surveyService.FrequencyPerHygieneQuestions().Values),
                "Equipment" => Ok(_surveyService.FrequencyPerEquipmentQuestions().Values),
                _ => BadRequest(),
            };
        }

        [HttpGet("answers-per-doctors/{id}")]
        public IActionResult AnswersPerDoctors(long id)
        {
            List<Section> sections = _surveyService.GetSurveysPerDoctors(id);
            return Ok(sections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());
        }

        [HttpGet("average-grade-per-doctor/{id}")]
        public IActionResult AveragreGradePerDoctor(long id)
        {
            return Ok(_surveyService.GetAvarageGradePerDoctors(id));
        }

        [HttpGet("getAllDoctors")]
        public IActionResult AllDoctors()
        {
            return Ok(_surveyService.GetDoctorsGrades(_requestSender).ToArray());
        }
    }
}
