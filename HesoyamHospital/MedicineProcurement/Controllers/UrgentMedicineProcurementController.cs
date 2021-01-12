using System;
using System.Collections.Generic;
using System.Linq;
using MedicineProcurement.DTOs;
using MedicineProcurement.Exceptions;
using MedicineProcurement.Model;
using MedicineProcurement.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapter.UrgentProcurement
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentMedicineProcurementController : ControllerBase
    {
        private readonly IUrgentMedicineProcurementService _urgentMedicineProcurementService;
        public UrgentMedicineProcurementController(IUrgentMedicineProcurementService urgentMedicineProcurementService)
        {
            _urgentMedicineProcurementService = urgentMedicineProcurementService;
        }
        [HttpPost("createRequest")]
        public IActionResult CreateUrgentMedicineProcurementRequest(UrgentMedicineProcurement urgentMedicine)
        {
            try
            {
                _urgentMedicineProcurementService.Create(urgentMedicine);
                return Ok();
            }
            catch(MedicineNullException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [HttpGet("getMedicineByID/{id}")]
        public IActionResult GetRequestedMedicineByID(long id)
        {
            UrgentMedicineProcurement entry = _urgentMedicineProcurementService.GetByID(id);
            return Ok(entry);
        }
        [HttpGet]
        public IActionResult GetAllUnconcludedEntries()
        {
            List<UrgentMedicineProcurement> entries = _urgentMedicineProcurementService.GetAllUnconcluded().ToList();
            return Ok(entries);
        }
        [HttpPost("getPharmacies/{id}")]
        public IActionResult GetPharmaciesByRequiredMedicine([FromBody] List<RegisteredPharmacyDTO> pharmacies, long id)
        {
            UrgentMedicineProcurement urgentMedicine = _urgentMedicineProcurementService.GetByID(id);
            List<RegisteredPharmacyDTO> availablePharmacies = _urgentMedicineProcurementService.GetPharmaciesByRequiredMedicine(pharmacies, urgentMedicine).ToList();
            return Ok(availablePharmacies);
        }
        [HttpPut("{id}")]
        public IActionResult PurchaseMedicine([FromBody] RegisteredPharmacyDTO pharmacy, long urgentMedicineId)
        {
            bool successful = _urgentMedicineProcurementService.IsProcurementRequestSuccessfull(pharmacy, urgentMedicineId);
            if (successful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
