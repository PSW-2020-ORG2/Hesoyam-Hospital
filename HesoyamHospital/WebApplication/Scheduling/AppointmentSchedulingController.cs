using System;
using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using WebApplication.MedicalRecords;
using WebApplication.Scheduling.Service;

namespace WebApplication.Scheduling
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSchedulingController : ControllerBase
    {
        private readonly IAppointmentSchedulingService _appointmentSchedulingService;
        public AppointmentSchedulingController(IAppointmentSchedulingService appointmentSchedulingService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
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
            Patient patient = AppResources.getInstance().patientRepository.GetByID(id);
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
            Patient patient = AppResources.getInstance().patientRepository.GetByID(dto.PatientId);
            if (patient.SelectedDoctor == null) return NotFound();
            dto.DoctorId = patient.SelectedDoctor.Id;
            if (_appointmentSchedulingService.MultipleAppoitments(dto)) return BadRequest("SCHEDULING FAILED");
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto));
            return Ok();
        }
    }
}
