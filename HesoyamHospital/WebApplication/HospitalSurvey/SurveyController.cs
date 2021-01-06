using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Appointments.Service;

namespace WebApplication.HospitalSurvey
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public SurveyController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("send-answers/{appointmentId}")]
        public IActionResult SendAnswersOfSurvey([FromBody] SurveyDTO dto, long appointmentId)
        {
            Appointment appointment = _appointmentService.GetByID(appointmentId);
            if (!SurveyValidation.IsNewSurveyValid(dto, appointment)) return BadRequest();

            Doctor doctor = _appointmentService.GetDoctorAtAppointment(appointmentId);
            AppResources.getInstance().surveyService.Create(SurveyMapper.SurveyDTOToSurvey(dto, doctor));
            _appointmentService.DeactivateFillingOutSurvey(appointmentId);
            
            return Ok();
        }

        [HttpGet("get-answers")]
        public IActionResult GetAllAnswers()
        {
            List<Survey> surveys = AppResources.getInstance().surveyService.GetAll().ToList();

            if (surveys == null) return NotFound();

            return Ok(surveys.Select(survey => SurveyMapper.SurveyToSurveyDTO(survey)).ToArray());
            

        }

        [HttpGet("get-answers-per-section/{section}")]
        public IActionResult GetAnswersPerSections(string section)
        {
            List<Section> doctorSections = AppResources.getInstance().surveyService.GetAnswersPerDoctorSections();
            List<Section> staffSections = AppResources.getInstance().surveyService.GetAnswersPerStaffSections();
            List<Section> hygieneSections = AppResources.getInstance().surveyService.GetAnswersPerHygieneSections();
            List<Section> equipmentSections = AppResources.getInstance().surveyService.GetAnswersPerEquipmentSections();
           
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
                AppResources.getInstance().surveyService.MeanValuesPerDoctorSection(),
                AppResources.getInstance().surveyService.MeanValuesPerStaffSection(),
                AppResources.getInstance().surveyService.MeanValuesPerHygieneSection(),
                AppResources.getInstance().surveyService.MeanValuesPerEquipmentSection()
            };

            List<MeanDTO> result = new List<MeanDTO>();
            MeanDTO dto = new MeanDTO(means[0], means[1], means[2], means[3]);
            result.Add(dto);
            return Ok(result.ToArray());


            
        }
        [HttpGet("mean-value-per-question/{section}")]
        public IActionResult MeanValuePerQuestion(string section)
        {
            List<double> meanArrayDoctor = AppResources.getInstance().surveyService.MeanValuesPerDoctorQuestions();
            List<double> meanArrayStaff = AppResources.getInstance().surveyService.MeanValuesPerStaffQuestions();
            List<double> meanArrayHygiene = AppResources.getInstance().surveyService.MeanValuesPerHygieneQuestions();
            List<double> meanArrayEquipment = AppResources.getInstance().surveyService.MeanValuesPerEquipmentQuestions();
            List<MeanDTO> means = new List<MeanDTO>();
            List<MeanDTO> means2 = new List<MeanDTO>();
            List<MeanDTO> means3 = new List<MeanDTO>();
            List<MeanDTO> means4 = new List<MeanDTO>();
            MeanDTO dto = new MeanDTO(meanArrayDoctor[0],meanArrayDoctor[1], meanArrayDoctor[2],meanArrayDoctor[3]);
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
                "Doctor" => Ok(AppResources.getInstance().surveyService.FrequencyPerDoctorQuestions().Values),
                "Staff" => Ok(AppResources.getInstance().surveyService.FrequencyPerStaffQuestions().Values),
                "Hygiene" => Ok(AppResources.getInstance().surveyService.FrequencyPerHygieneQuestions().Values),
                "Equipment" => Ok(AppResources.getInstance().surveyService.FrequencyPerEquipmentQuestions().Values),
                _ => BadRequest(),
            };
        }
        [HttpGet("answers-per-doctors/{id}")]
        public IActionResult AnswersPerDoctors(long id)
        {
            Doctor doctor = AppResources.getInstance().doctorService.GetByID(id);

            if (doctor == null)
            {
                return BadRequest();
            }
            List<Section> sections = AppResources.getInstance().surveyService.GetSurveysPerDoctors(doctor);
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
            List<DoctorDTO> dtos = new List<DoctorDTO>();
            foreach(Doctor doctor in doctors) {
                DoctorDTO dto = DoctorMapper.DoctorToDoctorDTO(doctor);
                dto.AverageGrade = AppResources.getInstance().surveyService.GetAvarageGradePerDoctors(doctor);
                dtos.Add(dto);
            }
            return Ok(dtos.ToArray());

        }
    }
}
