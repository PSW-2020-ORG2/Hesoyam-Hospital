using System.Collections.Generic;
using System.Linq;
using Authentication.Model.FeedbackModel;
using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using Feedbacks.DTOs;
using Feedbacks.Mappers;
using Feedbacks.Service.Abstract;
using Feedbacks.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ISurveyService _surveyService;
        private readonly IDoctorService _doctorService;
        public SurveyController(IAppointmentService appointmentService, ISurveyService surveyService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _surveyService = surveyService;
            _doctorService = doctorService;
        }

        [HttpPost("send-answers/{appointmentId}")]
        public IActionResult SendAnswersOfSurvey([FromBody] SurveyDTO dto, long appointmentId)
        {
            Appointment appointment = _appointmentService.GetByID(appointmentId);
            if (!SurveyValidation.IsNewSurveyValid(dto, appointment)) return BadRequest();

            Doctor doctor = _appointmentService.GetDoctorAtAppointment(appointmentId);
            _surveyService.Create(SurveyMapper.SurveyDTOToSurvey(dto, doctor));
            _appointmentService.DeactivateFillingOutSurvey(appointmentId);

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
            Doctor doctor = _doctorService.GetByID(id);

            if (doctor == null)
            {
                return BadRequest();
            }
            List<Section> sections = _surveyService.GetSurveysPerDoctors(doctor);
            return Ok(sections.Select(section => SectionMapper.SectionToSectionDTO(section)).ToArray());
        }

        [HttpGet("average-grade-per-doctor/{id}")]
        public IActionResult AveragreGradePerDoctor(long id)
        {
            Doctor doctor = _doctorService.GetByID(id);

            if (doctor == null)
            {
                return BadRequest();
            }
            return Ok(_surveyService.GetAvarageGradePerDoctors(doctor));
        }

        [HttpGet("getAllDoctors")]
        public IActionResult AllDoctors()
        {
            List<Doctor> doctors = _doctorService.GetAll().ToList();
            if (doctors == null)
            {
                return BadRequest();
            }
            List<DoctorDTO> dtos = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
            {
                DoctorDTO dto = DoctorMapper.DoctorToDoctorDTO(doctor);
                dto.AverageGrade = _surveyService.GetAvarageGradePerDoctors(doctor);
                dtos.Add(dto);
            }
            return Ok(dtos.ToArray());

        }
    }
}
