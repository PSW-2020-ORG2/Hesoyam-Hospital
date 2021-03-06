﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Model.Appointments
{
    public class AppointmentEvent
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public long PatientID { get; set; }
        public long DoctorID { get; set; }



        public AppointmentType AppointmentType { get; set; }

        public AppointmentEvent() : base()
        {

        }

        public AppointmentEvent(DateTime timestamp, long patientID, long doctorID, AppointmentType appointmentType)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentType = appointmentType;
            Timestamp = timestamp;
        }

    }
}
