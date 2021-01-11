using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Appointments.DTOs;
using Appointments.Mappers;
using Appointments.Model;
using Appointments.Service;
using Appointments.Service.Abstract;
using Appointments.Validation;
using Microsoft.AspNetCore.Mvc;
using EventSourceClasses;
using EventSourceClasses.Appointments;

namespace Appointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly AppointmentValidation _appointmentValidation;
        private readonly IHttpRequestSender _httpRequestSender;
        private readonly EventLogger _appointmentEventLogger;

        public AppointmentController(IAppointmentService appointmentService, IHttpClientFactory httpClientFactory)
        {
            _appointmentService = appointmentService;
            _appointmentValidation = new AppointmentValidation();
            _httpRequestSender = new HttpRequestSender(httpClientFactory);
            _appointmentEventLogger = new EventLogger();
        }

        [HttpGet("{id}")]
        public IActionResult GetAllByPatient(long id)
        {
            return Ok(AppointmentMapper.AppointmentToAppointmentForObservationDto(_appointmentService.GetAllByPatient(id).ToList(), _httpRequestSender));
        }

        [HttpPut("cancel")]
        public IActionResult Cancel([FromBody] long id)
        {
            Appointment appointment = _appointmentService.GetByID(id);
            if (appointment == null) return NotFound();
            
            if (!_appointmentValidation.IsPossibleToCancelAppointment(appointment, appointment.PatientId)) return BadRequest();
            _appointmentService.Cancel(appointment.PatientId, id);
            _appointmentEventLogger.log(new AppointmentEvent(DateTime.Now,appointment.PatientId ,appointment.DoctorInAppointmentId, AppointmentEventType.CANCELLED));
            return Ok();
        }

        [HttpGet("getSuspiciousPatients")]
        public IActionResult GetSuspiciousPatients()
        {
            List<BlockPatientDTO> suspiciousPatients = _appointmentService.GetSuspiciousPatients(_httpRequestSender);
            if (suspiciousPatients == null || suspiciousPatients.Count == 0) return NotFound();
            return Ok(suspiciousPatients);
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
