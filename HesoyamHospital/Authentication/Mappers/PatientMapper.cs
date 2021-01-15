using Authentication.DTOs;
using Authentication.Model;
using System.Collections.Generic;

namespace Authentication.Mappers
{
    public static class PatientMapper
    {
        public static PatientDTO PatientToPatientDTO(Patient patient)
            =>new PatientDTO(patient.Name, patient.Surname, patient.Jmbg, patient.Id);

        public static List<PatientDTO> PatientsToPatientDTOs(List<Patient> patients)
        {
            List<PatientDTO> dtos = new List<PatientDTO>();
            foreach (Patient patient in patients)
            {
                dtos.Add(PatientToPatientDTO(patient));
            }
            return dtos;
        }
    }
}
