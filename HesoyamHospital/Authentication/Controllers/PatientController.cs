using Authentication.Service.Abstract;
using Authentication.Model.UserModel;
using Microsoft.AspNetCore.Mvc;
using Authentication.DTOs;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("changeSelectedDoctor")]
        public IActionResult ChangeSelectedDoctor(SelectedDoctorDTO newDoctor)
        {
            Patient patient = _patientService.GetByUsername(newDoctor.Username);
            if (patient == null) return NotFound();
            patient = _patientService.ChangeSelectedDoctor(newDoctor.DoctorId, patient.Id);
            if (patient == null) return BadRequest();
            return Ok();
        }

        [HttpPut("block/{username}")]
        public IActionResult BlockPatient(string username)
        {
            Patient patient = _patientService.GetByUsername(username);
            if (patient == null) return BadRequest();
            _patientService.BlockPatient(patient);
            return Ok();
        }

        [HttpGet("getTimeTableForSelectedDoctor/{id}")]
        public IActionResult GetTimeTableForSelectedDoctor(long id)
            => Ok(_patientService.GetTimeTableForSelectedDoctor(id));

        [HttpGet("getSelectedDoctorId/{id}")]
        public IActionResult GetSelectedDoctorId(long id)
            => Ok(_patientService.GetSelectedDoctor(id));

        [HttpGet("getFullName/{id}")]
        public IActionResult GetFullName(long id)
            => Ok(_patientService.GetFullName(id));

        [HttpGet("getUsername/{id}")]
        public IActionResult GetUsername(long id)
            => Ok(_patientService.GetUsername(id));

        [HttpGet("isBlocked/{id}")]
        public IActionResult IsBlocked(long id)
            => Ok(_patientService.IsBlocked(id));
    }
}
