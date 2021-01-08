using EventSourcing.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventSourcing.Model.Authentication;

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationEventController : Controller
    {
        private readonly EventDbContext eventDbContext;

        public AuthenticationEventController(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        [HttpPost("createBlockEvent")]
        public IActionResult CreateBlockEvent([FromBody] BlockPatientEvent blockPatientEvent){
            eventDbContext.BlockPatientEvents.Add(blockPatientEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBlockEvent(long id)
        {
            BlockPatientEvent blockPatientEvent = eventDbContext.BlockPatientEvents.FirstOrDefault(blockPatientEvent => blockPatientEvent.Id == id);

            if (blockPatientEvent == null) return NotFound();

            return Ok(blockPatientEvent);
        }
        [HttpPost("createSelectedDoctorEvent")]
        public IActionResult CreateSelectedDoctorEvent([FromBody] SelectedDoctorEvent selectedDoctorEvent)
        {
            eventDbContext.SelectedDoctorEvents.Add(selectedDoctorEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSelectedDoctorEvent(long id)
        {
            SelectedDoctorEvent selectedDoctorEvent = eventDbContext.SelectedDoctorEvents.FirstOrDefault(selectedDoctorEvent => selectedDoctorEvent.Id == id);

            if (selectedDoctorEvent == null) return NotFound();

            return Ok(selectedDoctorEvent);
        }
    }
}
