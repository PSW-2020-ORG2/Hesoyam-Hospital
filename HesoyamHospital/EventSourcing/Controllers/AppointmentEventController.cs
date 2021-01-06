﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventSourcing.Model.Appointments;
using EventSourcing.Repository;
using EventSourcing.Exceptions;

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
            try
            {
                Validate(appointmentEvent);
            }
            catch (BadRequestException e) {
                return BadRequest(e.Message);
            }

            eventDbContext.AppointmentEvents.Add(appointmentEvent);
            eventDbContext.SaveChanges();
            return Ok();
        }

        private void Validate(AppointmentEvent appointmentEvent)
        {
            if (appointmentEvent.PatientID == null)
                throw new BadRequestException("Patient ID can not be null!");
            if (appointmentEvent.DoctorID == null)
                throw new BadRequestException("Doctor ID can not be null!");
            //if (appointmentEvent.Timestamp == null)
            //    throw new BadRequestException("Timestamp can not be null!");
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


        // POST api/<AppointmentEventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointmentEventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentEventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
