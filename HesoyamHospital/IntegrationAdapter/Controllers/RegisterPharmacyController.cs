using Backend;
using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPharmacyController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get(RegisteredPharmacy pharmacy)
        {
            try
            {
                AppResources.getInstance().registeredPharmacyService.Create(pharmacy);
                return Ok("Pharmacy with name " + pharmacy.PharmacyName + " registered.");
            } catch (RegisteredPharmacyNameNotUniqueException e)
            {
                return BadRequest("Pharmacy with name " + pharmacy.PharmacyName + " is already registered.");
            }
            catch (ValidationException e)
            {
                return BadRequest("Missing required data field.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return StatusCode(500);
            }
        }
    }
}
