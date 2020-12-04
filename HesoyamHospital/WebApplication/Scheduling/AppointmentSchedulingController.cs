using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (doctors == null) return NotFound();
            List<DoctorDTO> dtos = DoctorMapper.DoctorListToDTOList(doctors);
            return Ok(dtos.ToArray());
        }

        [HttpPut("getTimesForDoctor")]
        public IActionResult GetTimesForDoctor(DoctorDateDTO dto)
        {
            if (dto == null) return BadRequest();
            List<DateTime> availableAppointments =_appointmentSchedulingService.GetTimesForDoctorAndDate(dto.Id, dto.Date).ToList();
            if (availableAppointments == null) return NotFound();
            return Ok(IntervalMapper.DateTimesToIntervalDTOs(availableAppointments).ToArray());
        }

        [HttpPost("saveAppointment")]
        public IActionResult SaveAppointment(AppointmentDTO dto)
        {
            if (dto == null || dto.DoctorId == 0) return BadRequest();
            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto));
            return Ok();
        }
    }
}
