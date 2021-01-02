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
    }
}
