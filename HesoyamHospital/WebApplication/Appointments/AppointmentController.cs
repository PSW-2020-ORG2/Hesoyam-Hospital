using System.Linq;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
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
        private readonly AppointmentValidation _appointmentValidation;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
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
        public IActionResult BlockedList()
        {
            return Ok();
        }

        [HttpPut("block/{username}")]
        public IActionResult BlockPatient(string username)
        {
            Patient patient = AppResources.getInstance().patientRepository.GetPatientByUsername(username);
            if (patient == null) return BadRequest();
            return Ok();
        }
    }
}
