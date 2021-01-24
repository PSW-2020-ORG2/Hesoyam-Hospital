using System;
using System.Collections.Generic;
using System.Linq;
using MedicineProcurement.Exceptions;
using MedicineProcurement.Model;
using MedicineProcurement.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicineProcurement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }
        [HttpPost("createTender")]
        public IActionResult CreateTender(Tender tender)
        {
            try
            {
                _tenderService.Create(tender);
                return Ok();
            } catch (NullDateException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            } catch (InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            } catch (TenderListingsEmptyException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("concludeTender/{tenderId}/{winnerOfferId}")]
        public IActionResult ConcludeTender(long tenderId, long winnerOfferId, [FromBody] List<string> allEmails)
        {
            try
            {
                _tenderService.ConcludeTender(tenderId, winnerOfferId, allEmails);
                return Ok();
            } catch (NullDateException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
            catch (InvalidDateException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (TenderListingsEmptyException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (TenderStillActiveException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("active")]
        public IActionResult GetAllActiveTenders()
        {
            List<Tender> tenders = _tenderService.GetAllActiveTenders().ToList();
            return Ok(tenders);
        }
        [HttpGet("unconcluded")]
        public IActionResult GetAllUnconcludedTenders()
        {
            List<Tender> tenders = _tenderService.GetAllUnconcludedTenders().ToList();
            return Ok(tenders);
        }
    }
}
