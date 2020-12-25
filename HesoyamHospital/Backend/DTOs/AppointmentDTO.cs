using System;

namespace Backend.DTOs
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
