using System.Collections.Generic;
using System.Linq;
using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Documents.DTOs;
using Documents.Mappers;
using Documents.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Documents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService, IDoctorService doctorService, IPatientService patientService)
        {
            _medicalRecordService = medicalRecordService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpGet("show/{id}")]  //GET /api/medicalrecord/show/500
        public IActionResult GetMedicalRecordByPatientId(long id)
        {
            MedicalRecord medicalRecord = _medicalRecordService.GetPatientMedicalRecordByPatientId(id);
            if (medicalRecord == null) return NotFound();
            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }

        [HttpGet("allGeneralDoctors")]
        public IActionResult GetDoctors()
        {
            List<Doctor> doctors = _doctorService.GetDoctorByType(DoctorType.GENERAL_PRACTITIONER).ToList();
            if (doctors == null) return NotFound();
            List<DoctorDTO> dtos = DoctorMapper.DoctorListToDTOList(doctors);
            return Ok(dtos.ToArray());
        }

        [HttpPost("changeSelectedDoctor")]  //POST /api/medicalrecord/changeSelectedDoctor
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
