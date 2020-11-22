using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(NewPatientDTO dto)
        {
            if (dto == null) return BadRequest();
            AppResources.getInstance().patientService.Create(NewPatientMapper.NewPatientDTOToPatient(dto));
            AppResources.getInstance().medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
            return Ok();
        }
    }
}
