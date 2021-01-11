using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Model.Authentication 
{
    public class SelectedDoctorEvent
    { 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public long Id { get; set; }

        public long DoctorId { get; set; }
        public string Username { get; set; }


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
