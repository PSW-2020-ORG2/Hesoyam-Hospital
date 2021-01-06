using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventSourcing.Model.Appointments;
using EventSourcing.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentEventController : ControllerBase
    {
        private readonly EventDbContext eventDbContext;
        
        public AppointmentEventController(EventDbContext eventDbContext)
        {
            this.eventDbContext = eventDbContext;
        }

        [HttpPost ("create")]
        public IActionResult Create([FromBody] AppointmentEvent appointmentEvent)
        {
            if (appointmentEvent == null)
            {
                return BadRequest("Appoinment event must be provided.");
            }


            eventDbContext.AppointmentEvents.Add(appointmentEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }


        // GET: api/appointmentevent/id
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            AppointmentEvent appointmentEvent = eventDbContext.AppointmentEvents.FirstOrDefault(appointmentEvent => appointmentEvent.Id == id);

            if (appointmentEvent == null)
            {
                return NotFound();
            }

            return Ok(appointmentEvent);
        }
    }
}
