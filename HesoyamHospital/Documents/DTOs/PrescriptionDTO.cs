using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.DTOs
{
    public class PrescriptionDTO
    {
        public string DateTimeCreated { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialisation { get; set; }
        public string Diagnosis { get; set; }
        public List<TherapyDTO> Therapies { get; set; }

        public PrescriptionDTO()
        {

        }
        public PrescriptionDTO(DateTime dateTimeCreated, string doctorFullName, string doctorSpecialisation, string diagnosis, List<TherapyDTO> therapies)
        {
            DateTimeCreated = dateTimeCreated.ToString("dd.MM.yyyy");
            DoctorFullName = doctorFullName;
            DoctorSpecialisation = doctorSpecialisation;
            Diagnosis = diagnosis;
            Therapies = therapies;
        }
    }
}
