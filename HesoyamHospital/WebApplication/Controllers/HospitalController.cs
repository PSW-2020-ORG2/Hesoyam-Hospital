using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.UserModel;
using Backend.Service;
using Backend.Service.HospitalManagementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        public HospitalService hospitalService;

        public HospitalController(HospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public IEnumerable<Hospital> GetAll()
        {
            return hospitalService.GetAll();
        }
    }
}
