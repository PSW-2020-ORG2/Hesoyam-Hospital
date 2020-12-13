using System;
using System.Collections.Generic;
using System.Linq;
using Backend;
using Backend.Model.PatientModel;
using Backend.Model.PharmacyModel;
using Grpc.Core;
using IntegrationAdapter.DTOs;
using IntegrationAdapter.Protos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public MedicineController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Medicine> medicines = AppResources.getInstance().medicineService.GetAll().ToList();
                return Ok(medicines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{pharmacyName}/{medicineName}")]
        public IActionResult GetSpecification(string pharmacyName, string medicineName)
        {
            MedicineAvailabilityDTO retVal;
            RegisteredPharmacy pharmacy = AppResources.getInstance().registeredPharmacyService.GetRegisteredPharmacyByName(pharmacyName);
            if (_environment.IsDevelopment())
            {
                if (!string.IsNullOrEmpty(pharmacy.GrpcPort))
                {
                    retVal = SendGrpcRequest(pharmacy, medicineName);
                }
                else
                {
                    retVal = SendHttpRequest(pharmacy, medicineName);
                }
            }
            else
            {
                retVal = SendHttpRequest(pharmacy, medicineName);
            }
            
            if(retVal != null)
            {
                return Ok(retVal);
            }
            else
            {
                return StatusCode(500);
            }
        }

        private MedicineAvailabilityDTO SendGrpcRequest(RegisteredPharmacy pharmacy, string medicineName)
        {
            Channel channel = new Channel(pharmacy.Endpoint + ":" + pharmacy.GrpcPort, ChannelCredentials.Insecure);
            PharmacyGrpcService.PharmacyGrpcServiceClient client = new PharmacyGrpcService.PharmacyGrpcServiceClient(channel);
            try
            {
                MedicineAvailabilityProto proto = client.IsMedicineAvailable(new MedicineNameProto { MedicineName = medicineName });
                MedicineAvailabilityDTO dto = JsonConvert.DeserializeObject<MedicineAvailabilityDTO>(proto.ToString());
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private MedicineAvailabilityDTO SendHttpRequest(RegisteredPharmacy pharmacy, string medicineName)
        {
            throw new NotImplementedException();
        }
    }
}
