using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Backend.Model.PharmacyModel;
using Grpc.Core;
using IntegrationAdapter.Protos;
using RestSharp;
using Backend;
using Microsoft.Extensions.Hosting;
using Backend.Model.PatientModel;
using IntegrationAdapter.UrgentProcurement.Service;
using Backend.Exceptions;

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
        [HttpGet("getPharmacies/{id}")]
        public IActionResult GetPharmaciesByRequiredMedicine(long id)
        {
            UrgentMedicineProcurement urgentMedicine = _urgentMedicineProcurementService.GetByID(id);
            List<RegisteredPharmacy> availablePharmacies = _urgentMedicineProcurementService.GetPharmaciesByRequiredMedicine(urgentMedicine).ToList();
            return Ok(availablePharmacies);
        }
        [HttpPut("{pharmacyName}")]
        public IActionResult PurchaseMedicine(string pharmacyName, UrgentMedicineProcurement urgentMedicine)
        {
            bool successful = _urgentMedicineProcurementService.IsProcurementRequestSuccessfull(pharmacyName, urgentMedicine);
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
