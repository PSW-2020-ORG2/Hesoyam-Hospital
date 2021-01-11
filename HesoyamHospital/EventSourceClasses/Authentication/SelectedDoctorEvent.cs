using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses.Authentication
{
    public class SelectedDoctorEvent : Event
    {
        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("selectedDoctorEventLoggerURL");
        public long DoctorId { get; set; }
        public string Username { get; set; }

        public long Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public SelectedDoctorEvent() { }

        public SelectedDoctorEvent(long doctorID, string username) 
        {
            DoctorId = doctorID;
            Username = username;
        }
        public SelectedDoctorEvent(long doctorID, string username, DateTime timestamp) 
        {
            DoctorId = doctorID;
            Username = username;
            Timestamp = timestamp;
        }

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Serilization error occured during logging changing doctor selection.");
            }

        }
    }
}
