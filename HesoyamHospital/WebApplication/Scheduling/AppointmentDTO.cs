using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling
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
