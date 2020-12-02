using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Scheduling.Service;

namespace WebApplication.Scheduling
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentSchedulingService _appointmentSchedulingService;
        public AppointmentController(IAppointmentSchedulingService appointmentSchedulingService)
        {
            _appointmentSchedulingService = appointmentSchedulingService;
        }

        [HttpGet("getDoctorsByType/{type}")]
        public IActionResult GetDoctorsByType(string type)
        {
            _appointmentSchedulingService.GetDoctorsByType(type);
            return Ok();
        }

        [HttpPost("getTimesForDoctor")]
        public IActionResult GetTimesForDoctor(DoctorDateDTO dto)
        {
            if (dto == null) return BadRequest();
            
           _appointmentSchedulingService.GetTimesForDoctorAndDate(dto.Id, dto.Date);
            return Ok();
        }

        [HttpPost("saveAppointment")]
        public IActionResult SaveAppointment(AppointmentDTO dto)
        {
            if (dto == null) return BadRequest();

            _appointmentSchedulingService.SaveAppointment(AppointmentMapper.AppointmentDtoToAppointment(dto));
            return Ok();
        }
    }
}
