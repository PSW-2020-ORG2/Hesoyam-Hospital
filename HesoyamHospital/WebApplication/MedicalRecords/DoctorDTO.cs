using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public class DoctorDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO() { }

        public DoctorDTO(long id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }
    }
}
