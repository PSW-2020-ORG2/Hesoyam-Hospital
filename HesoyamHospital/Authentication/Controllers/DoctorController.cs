using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Service.Abstract;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("getAllDoctorIds")]
        public IActionResult GetAllDoctorIds()
            => Ok(_doctorService.GetAllDoctorIds());

        [HttpGet("getUsername/{id}")]
        public IActionResult GetUsername(long id)
            => Ok(_doctorService.GetUsername(id));
    }
}
