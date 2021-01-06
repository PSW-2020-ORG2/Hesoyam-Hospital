using System;

namespace Appointments.DTOs
{
    public class DoctorDateDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public DoctorDateDTO() { }
        public DoctorDateDTO(long id, DateTime date)
        {
            Id = id;
            Date = date;
        }
        

    }
}
