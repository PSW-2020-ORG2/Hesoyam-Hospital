using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Appointments.Service;

namespace WebApplication.Appointments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly long defaultPatientId = 500;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAllByPatient(long id)
        {
            if (id != defaultPatientId) return BadRequest();
            return Ok(AppointmentMapper.AppointmentToAppointmentForObservationDto(_appointmentService.GetAllByPatient(id).ToList()));
        }

        [HttpPut("cancel/{id}")]
        public IActionResult Cancel(long id)
        {
            if (_appointmentService.GetByID(id) == null) return NotFound();
            _appointmentService.Cancel(id);
            return Ok();
        }
    }
}
