using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Medicines.DTOs;
using Medicines.Exceptions;
using Medicines.Model;
using Medicines.Service;
using Medicines.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapyController : ControllerBase
    {
        private readonly ITherapyService _therapyService;
        private readonly IMedicineService _medicineService;
        private readonly IHttpRequestSender _httpRequestSender;
        public TherapyController(ITherapyService therapyService, IMedicineService medicineService, IHttpClientFactory httpClientFactory)
        {
            _therapyService = therapyService;
            _medicineService = medicineService;
            _httpRequestSender = new HttpRequestSender(httpClientFactory);
        }

        [HttpPost("addTherapy")]
        public IActionResult AddTherapy([FromBody] TherapyDTO dto)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach(long id in dto.MedicineIds)
            {
                medicines.Add(_medicineService.GetByID(id));
            }

            Therapy therapy = TherapyDTO.TherapyDTOToTherapy(dto, medicines);

            try
            {
                _therapyService.Create(therapy);
                return Ok(therapy.Id);
            } catch (TherapyServiceException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("sendPrescription/{id}/{uidn}")]
        public IActionResult SendPrescription([FromBody] RegisteredPharmacyDTO registeredPharmacy, long id, string uidn)
        {
            try
            {
                Therapy therapy = _therapyService.GetByID(id);
                string patientFullName = _httpRequestSender.GetPatientFullName(therapy.Prescription.PatientId);
                _therapyService.SendTherapyToPharmacy(therapy, patientFullName, uidn, registeredPharmacy);
                return Ok();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "An unknown error has occured.");
            }
        }
    }
}
