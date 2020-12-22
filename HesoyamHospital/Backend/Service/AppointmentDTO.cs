using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class AppointmentDTO
    {
        public DateTime DateAndTime { get; set; }
        public long DoctorId { get; set; }

        public AppointmentDTO() { }

        public AppointmentDTO(DateTime dateAndTime, long doctorId)
        {
            DateAndTime = dateAndTime;
            DoctorId = doctorId;
        }
    }
}
