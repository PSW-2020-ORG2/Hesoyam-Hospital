using IntegrationAdapter.SMTPServiceSupport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOffersController : ControllerBase
    {
        [HttpGet("finalize/{winner}")]
        public IActionResult FinalizeOffer(string winner)
        {
            //List<string> sviMailovi = appresources.getinstance().tenderService.getAll();
            //foreach (mail mail in sviMailovi)
           // {
               // if (mail.equals(winner))
                    SMTPNotificationSender.SendMessageToAllPharmacies("heshospital@gmail.com",
                                                                              "Tender offer period has concluded.",
                                                                              "Congratulations,your tender offer was accepted! You will be contacted with further details.");
                //else
                 //   SMTPNotificationSender.SendMessageToAllPharmacies(mail,
                                                                           //   "Tender offer period has concluded.",
                                                                           //   "We are sorry to announce that your tender offer wasn't accepted.We appretiate your effort.");
          //  }
          //delete tender iz baze?
            //upisi u bazu to sto je navedeno u tenderu?
            return Ok();
        }
    }
}
