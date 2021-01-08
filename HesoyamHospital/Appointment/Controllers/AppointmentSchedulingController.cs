using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Appointments.DTOs;
using Appointments.Mappers;
using Appointments.Service;
using Appointments.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using EventSourceClasses;
using EventSourceClasses.Appointments;

namespace Appointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingController : ControllerBase
    {
        private readonly IAppointmentSchedulingService _appointmentSchedulingService;
        private readonly IHttpRequestSender _httpRequestSender;
        private readonly EventLogger _appointmentEventLogger;

        public AppointmentSchedulingController(IAppointmentSchedulingService appointmentSchedulingService, IHttpClientFactory httpClientFactory)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
            _httpRequestSender = new HttpRequestSender(httpClientFactory);
            _appointmentEventLogger = new EventLogger();
        }

        [HttpPut("getTimesForDoctor")]
        public IActionResult GetTimesForDoctor(DoctorDateDTO dto)
        {
            if (dto == null) return BadRequest();
            List<DateTime> availableAppointments = _appointmentSchedulingService.GetTimesForDoctorAndDate(dto.Id, dto.Date, _httpRequestSender).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(IntervalMapper.DateTimesToIntervalDTOs(availableAppointments).ToArray());
        }

        [HttpPost("recommendation")]
        public IActionResult GetTimesForDoctor(PriorityDTO dto)
        {
            if (dto == null) return BadRequest();
            List<PriorityIntervalDTO> availableAppointments = _appointmentSchedulingService.GetRecommendedTimes(dto, _httpRequestSender).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(availableAppointments.ToArray());
        }

        [HttpGet("getTimesForSelectedDoctor/{id}")]
        public IActionResult GetTimesForSelectedDoctor(long id)
        {
            List<DateTime> availableAppointments = _appointmentSchedulingService.GetTimesForSelectedDoctor(id, _httpRequestSender).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(IntervalMapper.DateTimesToIntervalDTOs(availableAppointments).ToArray());
        }

        [HttpPost("saveAppointment")]
        public IActionResult SaveAppointment([FromBody] AppointmentDTO dto)
        {
            if (dto == null || dto.DoctorId == 0) return BadRequest();
            if (_appointmentSchedulingService.MultipleAppoitments(dto, _httpRequestSender)) return BadRequest("SCHEDULING FAILED");
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto, _httpRequestSender), _httpRequestSender);
            _appointmentEventLogger.log(new AppointmentEvent(DateTime.Now, dto.PatientId, dto.DoctorId, AppointmentEventType.CREATED));
            return Ok();
        }

        [HttpPost("saveSelectedDoctorAppointment")]
        public IActionResult SaveSelectedDoctorAppointment([FromBody] AppointmentDTO dto)
        {
            if (dto == null || dto.PatientId == 0) return BadRequest();
            dto.DoctorId = _appointmentSchedulingService.SetSelectedDoctor(dto.PatientId, _httpRequestSender);
            if (_appointmentSchedulingService.MultipleAppoitments(dto, _httpRequestSender)) return BadRequest("SCHEDULING FAILED");
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto, _httpRequestSender), _httpRequestSender);
            _appointmentEventLogger.log(new AppointmentEvent(DateTime.Now, dto.PatientId, dto.DoctorId, AppointmentEventType.CREATED));
            return Ok();
        }
    }
}
