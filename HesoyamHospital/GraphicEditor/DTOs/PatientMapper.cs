using Backend.Model.UserModel;
using System.Collections.Generic;

namespace GraphicEditor.DTOs
{
    public static class PatientMapper
    {
        public static List<PatientDTO> ConvertFromPatientToDTO(List<Patient> patients)
        {
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient p in patients)
            {
                PatientDTO patient = new PatientDTO(p.Id, p.Name, p.Surname, p.Jmbg, p.DateOfBirth.ToString());
                result.Add(patient);
            }
            return result;
        }
    }
}
