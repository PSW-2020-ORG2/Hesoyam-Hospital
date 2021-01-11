using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medicines.DTOs;
using Medicines.Model;
using Medicines.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MedicineDTO> medicineDTOs = new List<MedicineDTO>();
            foreach(Medicine medicine in _medicineService.GetAll().ToList())
            {
                medicineDTOs.Add(new MedicineDTO(medicine.Id, medicine.Name));
            }
            return Ok(medicineDTOs);
        }

        [HttpGet("getAvailability/{medicineName}")]
        public IActionResult GetMedicineAvailability([FromBody] RegisteredPharmacyDTO registeredPharmacy, string medicineName)
        {
            try
            {
                MedicineAvailabilityDTO medicineAvailability = _medicineService.GetMedicineAvailability(medicineName, registeredPharmacy);
                return Ok(medicineAvailability);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
            
        }
    }
}
