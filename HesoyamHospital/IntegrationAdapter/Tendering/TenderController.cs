using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using IntegrationAdapter.Tendering.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapter.Tendering
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
        [HttpGet]
        public IActionResult GetAllActiveTenders()
        {
            List<Tender> tenders = _tenderService.GetAllActiveTenders().ToList();
            return Ok(tenders);
        }
        [HttpGet]
        public IActionResult GetAllUnconcludedTenders()
        {
            List<Tender> tenders = _tenderService.GetAllUnconcludedTenders().ToList();
            return Ok(tenders);
        }
    }
}
