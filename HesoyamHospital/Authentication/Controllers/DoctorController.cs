using System.Collections.Generic;
using System.Linq;
using Authentication.DTOs;
using Authentication.Mappers;
using Authentication.Model.UserModel;
using Authentication.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getFullName/{id}")]
        public IActionResult GetFullName(long id)
            => Ok(_doctorService.GetFullName(id));

        [HttpGet("getAllDoctorIds")]
        public IActionResult GetAllDoctorIds()
            => Ok(_doctorService.GetAllDoctorIds());

        [HttpGet("getUsername/{id}")]
        public IActionResult GetUsername(long id)
            => Ok(_doctorService.GetUsername(id));

        [HttpGet("allGeneralDoctors")]
        public IActionResult GetDoctors()
        {
            List<Doctor> doctors = _doctorService.GetDoctorByType(DoctorType.GENERAL_PRACTITIONER).ToList();
            if (doctors == null) return NotFound();
            List<DoctorDTO> dtos = DoctorMapper.DoctorListToDTOList(doctors);
            return Ok(dtos.ToArray());
        }
    }
}
