using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventSourceClasses.Appointments
{
    public class AppointmentEvent : Event
    {
        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("appointmentEventLoggerURL");

        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public long PatientID { get; set; }
        public long DoctorID { get; set; }



        public AppointmentEventType AppointmentType { get; set; }

        public AppointmentEvent() : base()
        {

        }

        public AppointmentEvent(DateTime timestamp, long patientID, long doctorID, AppointmentEventType appointmentType)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentType = appointmentType;
            Timestamp = timestamp;
        }

        public AppointmentEvent(long patientID, long doctorID, AppointmentEventType appointmentType)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentType = appointmentType;
        }

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Serilization error occured during login attempt.");
            }
        }
    }
}
