using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        [HttpGet("show")]  //GET /api/medicalrecord/show
        public IActionResult GetMedicalRecordByPatientId()
        {
            MedicalRecord medicalRecord = AppResources.getInstance().medicalRecordService.GetPatientMedicalRecordByPatientId(500);

            if (medicalRecord == null) return NotFound();

            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }
    }
}