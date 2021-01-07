using System;

namespace Appointments.DTOs
{
    public class AppointmentDTO
    {
        public long PatientId { get; set; }
        public DateTime DateAndTime { get; set; }
        public long DoctorId { get; set; }

        public AppointmentDTO() { }

        public AppointmentDTO(long patientId, DateTime dateAndTime, long doctorId)
        {
            PatientId = patientId;
            DateAndTime = dateAndTime;
            DoctorId = doctorId;
        }
    }
}
