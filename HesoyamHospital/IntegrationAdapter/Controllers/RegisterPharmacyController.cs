using Backend;
using Backend.Model.PharmacyModel;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPharmacyController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get(RegisteredPharmacy pharmacy)
        {
            if(AppResources.getInstance().registeredPharmacyService.GetRegisteredPharmacyByName(pharmacy.PharmacyName) == null)
            {
                AppResources.getInstance().registeredPharmacyService.Create(pharmacy);
                return Ok("Pharmacy registered.");
            }
            return BadRequest("Pharmacy already registered");
        }
    }
}
