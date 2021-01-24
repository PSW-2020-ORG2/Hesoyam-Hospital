using System;
using MedicineProcurement.Model;
using MedicineProcurement.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicineProcurement.Controllers
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
        [HttpGet("getAllOfferEmails/{id}")]
        public IActionResult GetAllOfferEmails(long id)
        {
            return Ok(_tenderOfferService.GetAllOfferEmails(id));
        }
    }
}
