using System;
using System.Collections.Generic;
using System.Linq;
using Appointments.DTOs;
using Appointments.Mappers;
using Appointments.Model.UserModel;
using Appointments.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingController : ControllerBase
    {
        private readonly IAppointmentSchedulingService _appointmentSchedulingService;
        private readonly IPatientService _patientService;

        public AppointmentSchedulingController(IAppointmentSchedulingService appointmentSchedulingService, IPatientService patientService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
            _patientService = patientService;
        }

        [HttpGet("getDoctorsByType/{type}")]
        public IActionResult GetDoctorsByType(string type)
        {
            List<Doctor> doctors = _appointmentSchedulingService.GetDoctorsByType(type);
            if (doctors == null || doctors.Count == 0) return NotFound();
            List<DoctorDTO> dtos = DoctorMapper.DoctorListToDTOList(doctors);
            return Ok(dtos.ToArray());
        }

        [HttpPut("getTimesForDoctor")]
        public IActionResult GetTimesForDoctor(DoctorDateDTO dto)
        {
            if (dto == null) return BadRequest();
            List<DateTime> availableAppointments = _appointmentSchedulingService.GetTimesForDoctorAndDate(dto.Id, dto.Date).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(IntervalMapper.DateTimesToIntervalDTOs(availableAppointments).ToArray());
        }

        [HttpPost("recommendation")]
        public IActionResult GetTimesForDoctor(PriorityDTO dto)
        {
            if (dto == null) return BadRequest();
            List<PriorityIntervalDTO> availableAppointments = _appointmentSchedulingService.GetRecommendedTimes(dto).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(availableAppointments.ToArray());
        }

        [HttpGet("getTimesForSelectedDoctor/{id}")]
        public IActionResult GetTimesForSelectedDoctor(long id)
        {
            Patient patient = _patientService.GetByID(id);
            if (patient == null || patient.SelectedDoctor == null) return BadRequest();
            List<DateTime> availableAppointments = _appointmentSchedulingService.GetTimesForSelectedDoctor(patient).ToList();
            if (availableAppointments == null || availableAppointments.Count == 0) return NotFound();
            return Ok(IntervalMapper.DateTimesToIntervalDTOs(availableAppointments).ToArray());
        }

        [HttpPost("saveAppointment")]
        public IActionResult SaveAppointment(AppointmentDTO dto)
        {
            if (dto == null || dto.DoctorId == 0) return BadRequest();
            if (_appointmentSchedulingService.MultipleAppoitments(dto)) return BadRequest("SCHEDULING FAILED");
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto));
            return Ok();
        }

        [HttpPost("saveSelectedDoctorAppointment")]
        public IActionResult SaveSelecetdDoctorAppointment(AppointmentDTO dto)
        {
            if (dto == null || dto.PatientId == 0) return BadRequest();
            Patient patient = _patientService.GetByID(dto.PatientId);
            if (patient.SelectedDoctor == null) return NotFound();
            dto.DoctorId = patient.SelectedDoctor.Id;
            if (_appointmentSchedulingService.MultipleAppoitments(dto)) return BadRequest("SCHEDULING FAILED");
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto));
            return Ok();
        }
    }
}
