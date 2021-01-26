using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public class ScheduledAppointmentDTO
    {

        public long Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public long DoctorId { get; set; }

        public ScheduledAppointmentDTO() { }

        public ScheduledAppointmentDTO(long id, DateTime dateAndTime, long doctorId)
        {
            Id = id;
            DateAndTime = dateAndTime;
            DoctorId = doctorId;
        }
    }
}
