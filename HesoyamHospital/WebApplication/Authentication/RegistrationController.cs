using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.UserModel;
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
            if (dto == null || !IsPatientValid(dto)) return BadRequest();
            AppResources.getInstance().patientService.Create(NewPatientMapper.NewPatientDTOToPatient(dto));
            AppResources.getInstance().medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
            return Ok();
        }

        private bool IsPatientValid(NewPatientDTO patient)
        {
            List<Patient> patientsList = new List<Patient>();
            if (RegistrationValidation.isNewPatientValid(patient) 
                && RegistrationValidation.IsUsernameUnique(patient.Username, patientsList)) return true;
            return false;
        }
    }
}
