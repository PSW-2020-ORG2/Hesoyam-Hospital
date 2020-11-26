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
        [HttpPost]   //POST /api/registration
        public IActionResult Add(NewPatientDTO dto)
        {
            if (dto == null || !IsPatientValid(dto)) return BadRequest();
            AppResources.getInstance().medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
            return Ok();
        }

        public bool IsPatientValid(NewPatientDTO patient)
        {
            List<Patient> patients = AppResources.getInstance().patientService.GetAll().ToList();
            if (RegistrationValidation.isNewPatientValid(patient) 
                && RegistrationValidation.IsUsernameUnique(patient.Username, patients)) return true;
            return false;
        }
    }
}
