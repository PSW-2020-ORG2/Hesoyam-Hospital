using Backend;
using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                return Ok();
            } catch (RegisteredPharmacyNameNotUniqueException e)
            {
                return BadRequest(e.Message);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidRegisteredPharmacyEndpointException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            List<RegisteredPharmacy> pharmacyList = (List<RegisteredPharmacy>)AppResources.getInstance().registeredPharmacyService.GetAll();
            return Ok(pharmacyList);
        }
    }
}
