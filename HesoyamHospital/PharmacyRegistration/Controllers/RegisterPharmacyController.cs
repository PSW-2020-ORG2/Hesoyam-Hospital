using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyRegistration.DTOs;
using PharmacyRegistration.Exceptions;
using PharmacyRegistration.Model;
using PharmacyRegistration.Service.Abstract;

namespace PharmacyRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPharmacyController : ControllerBase
    {
        private readonly IRegisteredPharmacyService _registeredPharmacyService;
        public RegisterPharmacyController(IRegisteredPharmacyService registeredPharmacyService)
        {
            _registeredPharmacyService = registeredPharmacyService;
        }
        [HttpPost]
        public IActionResult Register(RegisterPharmacyDTO pharmacy)
        {
            try
            {
                _registeredPharmacyService.Create(new RegisteredPharmacy(pharmacy));
                return Ok();
            }
            catch (RegisteredPharmacyNameNotUniqueException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<RegisteredPharmacy> pharmacyList = _registeredPharmacyService.GetAll().ToList();
            return Ok(pharmacyList);
        }
    }
}
