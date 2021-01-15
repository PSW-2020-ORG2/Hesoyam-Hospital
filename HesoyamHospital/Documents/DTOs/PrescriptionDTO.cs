using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.DTOs
{
    public class PrescriptionDTO
    {
        public DateTime DateTimeCreated { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialisation { get; set; }
        public string Diagnosis { get; set; }
        public List<TherapyDTO> Therapies { get; set; }

        public PrescriptionDTO()
        {

        }
        public PrescriptionDTO(DateTime dateTimeCreated, string doctorFullName, string doctorSpecialisation, string diagnosis, List<TherapyDTO> therapies)
        {
            DateTimeCreated = dateTimeCreated;
            DoctorFullName = doctorFullName;
            DoctorSpecialisation = doctorSpecialisation;
            Diagnosis = diagnosis;
            Therapies = therapies;
        }
    }
}
