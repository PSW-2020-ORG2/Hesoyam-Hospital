using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.MedicalRecords
{
    public class SelectedDoctorDTO
    {
        public long DoctorId { get; set; }
        public string Username { get; set; }

        public SelectedDoctorDTO() { }

        public SelectedDoctorDTO(long id, string username)
        {
            DoctorId = id;
            Username = username;
        }
    }
}
