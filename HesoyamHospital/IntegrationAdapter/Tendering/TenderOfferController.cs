using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Model.PharmacyModel;
using IntegrationAdapter.Tendering.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAdapter.Tendering
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOfferController : ControllerBase
    {
        private readonly ITenderOfferService _tenderOfferService;
        public TenderOfferController(ITenderOfferService tenderOfferService)
        {
            _tenderOfferService = tenderOfferService;
        }
        [HttpPost("createOffer")]
        public IActionResult CreateTenderOffer(TenderOffer tenderOffer)
        {
            try
            {
                _tenderOfferService.Create(tenderOffer);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [HttpGet("getOffers/{id}")]
        public IActionResult GetAllOffersForTender(long id)
        {
            return Ok(_tenderOfferService.GetTenderOffersForTender(id));
        }
    }
}
