using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public class RescheduleAppointmentDTO
    {
        public long AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public long RoomId { get; set; }
        public double Minutes { get; set; }

        public RescheduleAppointmentDTO(long appointmentId, string doctorName, long roomId, double minutes)
        {
            AppointmentId = appointmentId;
            DoctorName = doctorName;
            RoomId = roomId;
            Minutes = minutes;
        }
    }
}
