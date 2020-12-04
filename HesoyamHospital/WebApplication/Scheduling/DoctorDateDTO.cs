using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Scheduling
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
