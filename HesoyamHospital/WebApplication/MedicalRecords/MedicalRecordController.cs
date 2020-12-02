using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        [HttpGet("show/{id}")]  //GET /api/medicalrecord/show/500
        public IActionResult GetMedicalRecordByPatientId(long id)
        {
            Backend.Model.PatientModel.MedicalRecord medicalRecord = AppResources.getInstance().medicalRecordService.GetPatientMedicalRecordByPatientId(id);

            if (medicalRecord == null) return NotFound();

            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }

        [HttpGet("allGeneralDoctors")]
        public IActionResult GetDoctors()
        {
            List<Doctor> doctors = AppResources.getInstance().doctorService.GetDoctorByType(DoctorType.GENERAL_PRACTITIONER).ToList();
            if (doctors == null) return NotFound();
            List<DoctorDTO> dtos = DoctorMapper.DoctorListToDTOList(doctors);
            return Ok(dtos.ToArray());
        }

        [HttpPost("changeSelectedDoctor")]  //POST /api/medicalrecord/changeSelectedDoctor
        public IActionResult ChangeSelectedDoctor(SelectedDoctorDTO newDoctor)
        {
            Patient patient = AppResources.getInstance().patientService.GetByUsername(newDoctor.Username);
            if (patient == null) return NotFound();
            patient = AppResources.getInstance().patientService.ChangeSelectedDoctor(newDoctor.DoctorId, patient.Id);
            if (patient == null) return BadRequest();
            return Ok();
        }

    }
}