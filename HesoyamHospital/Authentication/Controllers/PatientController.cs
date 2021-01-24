using Authentication.Service.Abstract;
using Authentication.Model;
using Microsoft.AspNetCore.Mvc;
using Authentication.DTOs;
using EventSourceClasses;
using EventSourceClasses.Authentication;
using Authentication.Mappers;
using System.Linq;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly EventLogger _patientEventLogger;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
            _patientEventLogger = new EventLogger();
        }
        
        [HttpPost("changeSelectedDoctor")]
        public IActionResult ChangeSelectedDoctor(SelectedDoctorDTO newDoctor)
        {
            Patient patient = _patientService.GetByUsername(newDoctor.Username);
            if (patient == null) return NotFound();
            patient = _patientService.ChangeSelectedDoctor(newDoctor.DoctorId, patient.Id);
            if (patient == null) return BadRequest();
            _patientEventLogger.log(new SelectedDoctorEvent(newDoctor.DoctorId, newDoctor.Username));
            return Ok();
        }

        [HttpPut("block/{username}")]
        public IActionResult BlockPatient(string username)
        {
            Patient patient = _patientService.GetByUsername(username);
            if (patient == null) return BadRequest();
            _patientService.BlockPatient(patient);
            _patientEventLogger.log(new BlockPatientEvent(username));
            return Ok();
        }

        [HttpGet("getTimeTableForSelectedDoctor/{id}")]
        public IActionResult GetTimeTableForSelectedDoctor(long id)
            => Ok(_patientService.GetTimeTableForSelectedDoctor(id));

        [HttpGet("getSelectedDoctorId/{id}")]
        public IActionResult GetSelectedDoctorId(long id)
            => Ok(_patientService.GetSelectedDoctor(id));

        [HttpGet("getAllPatients")]
        public IActionResult GetAllPatients()
            => Ok(PatientMapper.PatientsToPatientDTOs(_patientService.GetAll().ToList()).ToArray());

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
