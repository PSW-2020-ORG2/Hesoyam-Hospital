using Backend;
using Backend.Model.PharmacyModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsBenefitsController : ControllerBase
    {
        [HttpGet("approved")]
        public IActionResult GetApprovedActionsBenefits()
        {
            List<ActionBenefit> actionsBenefits = AppResources.getInstance().actionBenefitService.GetAllApprovedActionBenefits().ToList();

            return Ok(actionsBenefits);
        }

        [HttpGet("unapproved")]
        public IActionResult GetUnapprovedActionsBenefits()
        {
            List<ActionBenefit> actionsBenefits = AppResources.getInstance().actionBenefitService.GetAllUnapprovedActionBenefits().ToList();

            return Ok(actionsBenefits);
        }

        [HttpPut("approve/{id}")]
        public IActionResult ApproveActionBenefit(long id)
        {
            var action = AppResources.getInstance().actionBenefitService.GetByID(id);
            action.Approved = true;
            AppResources.getInstance().actionBenefitService.Update(action);
            return Ok();
        }

        /*
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteActionBenefit(long id)
        {
            var action = AppResources.getInstance().actionBenefitService.GetByID(id);
            AppResources.getInstance().actionBenefitService.Delete(action);
            return Ok("Action benefit deleted.");
        }
        */
    }
}
