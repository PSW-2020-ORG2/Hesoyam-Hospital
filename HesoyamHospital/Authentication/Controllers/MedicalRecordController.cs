using Microsoft.AspNetCore.Mvc;
using Authentication.Model;
using Authentication.Service.Abstract;
using Authentication.Mappers;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet("show/{id}")]
        public IActionResult GetMedicalRecordByPatientId(long id)
        {
            MedicalRecord medicalRecord = _medicalRecordService.GetPatientMedicalRecordByPatientId(id);
            if (medicalRecord == null) return NotFound();
            return Ok(MedicalRecordMapper.MedicalRecordToMedicalRecordDTO(medicalRecord));
        }

    }
}
