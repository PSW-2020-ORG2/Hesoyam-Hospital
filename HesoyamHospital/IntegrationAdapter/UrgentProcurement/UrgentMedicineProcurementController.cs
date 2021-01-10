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
            if (_urgentMedicineProcurementService.Create(urgentMedicine) != null)
            {
                return Ok();
            }
            return BadRequest();
            
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
            Console.WriteLine(urgentMedicine.Medicine);
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
