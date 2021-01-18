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
        [HttpPost("getPharmacies/{urgentMedicineId}")]
        public IActionResult GetPharmaciesByRequiredMedicine(List<RegisteredPharmacyDTO> pharmacies, long urgentMedicineId)
        {
            Console.WriteLine(pharmacies.Count);
            UrgentMedicineProcurement urgentMedicine = _urgentMedicineProcurementService.GetByID(urgentMedicineId);
            List<RegisteredPharmacyDTO> availablePharmacies = _urgentMedicineProcurementService.GetPharmaciesByRequiredMedicine(pharmacies, urgentMedicine).ToList();
            return Ok(availablePharmacies);
        }
        [HttpPut("{urgentMedicineId}")]
        public IActionResult PurchaseMedicine(RegisteredPharmacyDTO pharmacy, long urgentMedicineId)
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
