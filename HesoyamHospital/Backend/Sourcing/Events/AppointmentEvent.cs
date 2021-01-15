using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Sourcing.Events
{
    public class AppointmentEvent : Event
    {
        public string PatientID { get; set; }
        public string DoctorID { get; set; }

        public AppointmentType AppointmentType { get; set; }

        public AppointmentEvent(DateTime timestamp, string patientID, string doctorID, AppointmentType appointmentType) : base(timestamp)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentType = appointmentType;
        }

    }
}
