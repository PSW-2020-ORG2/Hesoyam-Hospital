using System.Collections.Generic;
using System.Linq;
using Appointments.DTOs;
using Appointments.Mappers;
using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using Appointments.Service.Abstract;
using Appointments.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly long defaultPatientId = 500;
        private readonly AppointmentValidation _appointmentValidation;

        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _appointmentValidation = new AppointmentValidation();
        }

        [HttpGet("{id}")]
        public IActionResult GetAllByPatient(long id)
        {
            if (id != defaultPatientId) return BadRequest();
            return Ok(AppointmentMapper.AppointmentToAppointmentForObservationDto(_appointmentService.GetAllByPatient(id).ToList()));
        }

        [HttpPut("cancel")]
        public IActionResult Cancel([FromBody] long id)
        {
            Appointment appointment = _appointmentService.GetByID(id);
            if (appointment == null) return NotFound();
            if (!_appointmentValidation.IsPossibleToCancelAppointment(appointment, defaultPatientId)) return BadRequest();
            _appointmentService.Cancel(defaultPatientId, id);
            return Ok();
        }

        [HttpGet("getSuspiciousPatients")]
        public IActionResult GetSuspiciousPatients()
        {
            List<BlockPatientDTO> suspiciousPatients = _appointmentService.GetSuspiciousPatients();
            if (suspiciousPatients == null || suspiciousPatients.Count == 0) return NotFound();
            return Ok(suspiciousPatients);
        }

        [HttpPut("block/{username}")]
        public IActionResult BlockPatient(string username)
        {
            Patient patient = _patientService.GetByUsername(username);
            if (patient == null) return BadRequest();
            _appointmentService.BlockPatient(patient);
            return Ok();
        }

        [HttpGet("surveyCanBeFilledOut/{appointmentId}")]
        public IActionResult SurveyCanBeFilledOut(long appointmentId)
            => Ok(_appointmentService.SurveyCanBeFilledOut(appointmentId));

        [HttpGet("getDoctorInAppointmentId/{appointmentId}")]
        public IActionResult GetDoctorInAppointmentId(long appointmentId)
            => Ok(_appointmentService.GetDoctorInAppointmentId(appointmentId));

        [HttpPut("deactivateFillingOutSurvey/{appointmentId}")]
        public IActionResult DeactivateFillingOutSurvey(long appointmentId)
        {
            _appointmentService.DeactivateFillingOutSurvey(appointmentId);
            return Ok();
        }
    }
}
