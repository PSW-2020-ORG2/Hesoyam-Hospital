using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceClasses.Authentication
{
    public class SelectedDoctorEvent
    {
        public long DoctorId { get; set; }
        public string Username { get; set; }

        public long Id { get; set; }
        public DateTime Timestamp { get; set; }

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
    }
}
