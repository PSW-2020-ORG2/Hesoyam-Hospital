using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.DTOs
{
    public class PatientDTO
    {
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public PatientDTO()
        {

        }
        public PatientDTO(string jmbg,string name,string surname)
        {
            Jmbg = jmbg;
            Name = name;
            Surname = surname;
        }
        public static PatientDTO PatientToPatientDTO(Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO(patient.Jmbg,patient.Name,patient.Surname);
            return patientDTO;
        }
    }
}
