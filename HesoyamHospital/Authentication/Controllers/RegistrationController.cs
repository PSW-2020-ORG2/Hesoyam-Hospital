using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Authentication.DTOs;
using Authentication.Mappers;
using Authentication.Model;
using Authentication.Repository.Abstract;
using Authentication.Service.Abstract;
using Authentication.Validation;
using Microsoft.AspNetCore.Mvc;
using EventSourceClasses;
using EventSourceClasses.Authentication;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IPatientService _patientService;
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IImageRepository _imageRepository;
        private readonly EventLogger _registrationLogger;

        public RegistrationController(ISendEmailService sendEmalService, IImageRepository imageRepository, IPatientService patientService, IMedicalRecordService medicalRecordService)
        {
            _sendEmailService = sendEmalService;
            _imageRepository = imageRepository;
            _patientService = patientService;
            _medicalRecordService = medicalRecordService;
            _registrationLogger = new EventLogger();
        }

        [HttpPost]   //POST /api/registration
        public IActionResult Add(NewPatientDTO dto)
        {
            if (dto == null || !RegistrationValidation.IsPatientValid(dto)) return BadRequest();
            MedicalRecord medicalRecord = _medicalRecordService.Create(NewPatientMapper.NewPatientDTOToMedicalRecord(dto));
            if (medicalRecord != null)
            {
                _sendEmailService.SendActivationEmail(medicalRecord.Patient.Id, medicalRecord.Patient.Email1);
            }
            _registrationLogger.log(new RegistrationEvent(
                dto.Name,
                dto.Surname,
                dto.MiddleName,
                dto.Gender,
                dto.Email,
                dto.Username,
                dto.Password,
                dto.DateOfBirth,
                dto.HealthCardNumber,
                dto.Jmbg,
                dto.MobilePhone,
                dto.HomePhone,
                dto.BloodType,
                dto.Allergies,
                dto.Country,
                dto.City,
                dto.Address));
            return Ok();
        }

        [HttpPost("upload"), DisableRequestSizeLimit]   //POST /api/registration/upload
        public IActionResult UploadPicture()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    _imageRepository.SaveImage(file, fileName);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"internal server error: {ex}");
            }
        }

        [HttpPost("activate/{token}")]   //POST /api/registration/activate/token123
        public IActionResult Activate(string token)
        {
            long id = _sendEmailService.TokenToId(token);
            Patient patient = _patientService.Activate(id);
            if (patient == null) return BadRequest();
            return Ok();
        }
    }
}
