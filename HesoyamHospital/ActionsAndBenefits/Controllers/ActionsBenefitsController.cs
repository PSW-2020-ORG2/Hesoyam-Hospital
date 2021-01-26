using ActionsAndBenefits.Model;
using ActionsAndBenefits.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionsAndBenefits.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsBenefitsController : ControllerBase
    {
        private readonly IActionBenefitService _actionBenefitService;
        public ActionsBenefitsController(IActionBenefitService actionBenefitService)
        {
            _actionBenefitService = actionBenefitService;
        }

        [HttpGet("approved")]
        public IActionResult GetApprovedActionsBenefits()
        {
            List<ActionBenefit> actionsBenefits = _actionBenefitService.GetAllApprovedActionBenefits().ToList();
            return Ok(actionsBenefits);
        }

        [HttpGet("approvedText")]
        public IActionResult GetApprovedActionsBenefitsText()
        {
            List<string> actionsBenefits = _actionBenefitService.GetAllApprovedActionBenefitsText().ToList();
            return Ok(actionsBenefits.ToArray());
        }

        [HttpGet("unapproved")]
        public IActionResult GetUnapprovedActionsBenefits()
        {
            List<ActionBenefit> actionsBenefits = _actionBenefitService.GetAllUnapprovedActionBenefits().ToList();
            return Ok(actionsBenefits);
        }

        [HttpPut("approve/{id}")]
        public IActionResult ApproveActionBenefit(long id)
        {
            ActionBenefit actionBenefit = _actionBenefitService.GetByID(id);
            if(actionBenefit != null)
            {
                _actionBenefitService.Approve(actionBenefit);
                return Ok();
            }
            return NotFound("Notification with id " + id + " could not be found.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteActionBenefit(long id)
        {
            ActionBenefit action = _actionBenefitService.GetByID(id);
            if(action != null)
            {
                try
                {
                    _actionBenefitService.Delete(action);
                    return Ok();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500, "An error has occured.");
                }
            }
            return NotFound("Notification with id " + id + " could not be found.");
            
        }
    }
}
