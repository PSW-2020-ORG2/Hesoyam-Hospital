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
        [HttpGet]
        public IActionResult GetAllUrgentProcurementEntries()
        {
            List<UrgentMedicineProcurement> entries = _urgentMedicineProcurementService.GetAll().ToList();
            return Ok(entries);
        }
        [HttpGet("getPharmacies")]
        public IActionResult GetPharmaciesByRequiredMedicine(UrgentMedicineProcurement urgentMedicine)
        {
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
