﻿using System;
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
        [HttpGet("show/{id}")]  //GET /api/medicalrecord/show
        public IActionResult GetMedicalRecordByPatientId(long id)
        {
            MedicalRecord medicalRecord = AppResources.getInstance().medicalRecordService.GetPatientMedicalRecordByPatientId(id);

            if (medicalRecord == null) return NotFound();

            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }

        [HttpGet("image/{imageName}")]
        public IActionResult GetImage(String imageName)
        {
            Byte[] b;
            try
            {
                b = System.IO.File.ReadAllBytes(@"../WebApplication/Resources/images/" + imageName);
            }
            catch (Exception e) {
                b = System.IO.File.ReadAllBytes(@"../WebApplication/Resources/images/anjaa.jpg");
            }
            return File(b, "image/jpg");
        }
    }
}