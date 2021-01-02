using Authentication.Model.MedicalRecordModel;
using Authentication.Model.UserModel;
using Authentication.DTOs;
using System.Globalization;


namespace Authentication.Mappers
{
    public static class MedicalRecordMapper
    {
        public static MedicalRecordDTO MedicalRecordToMedicalRecordDTO(MedicalRecord medicalRecord)
        {
            MedicalRecordDTO dto = new MedicalRecordDTO
            {
                FirstName = medicalRecord.Patient.Name,
                LastName = medicalRecord.Patient.Surname,
                MiddleName = medicalRecord.Patient.MiddleName,
                Address = medicalRecord.Patient.Address.ToString(),
                DateOfBirth = medicalRecord.Patient.DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")),
                MedicalId = medicalRecord.Patient.HealthCardNumber,
                PersonalId = medicalRecord.Patient.Jmbg,
                MobilePhone = medicalRecord.Patient.CellPhone,
                HomePhone = medicalRecord.Patient.HomePhone,
                Email = medicalRecord.Patient.Email1,
                Username = medicalRecord.Patient.UserName,
                Password = medicalRecord.Patient.Password,
                BloodType = medicalRecord.BloodTypeToString(medicalRecord.PatientBloodType),
                SelectedDoctorName = GetSelectedDoctorsName(medicalRecord.Patient),
                Alergies = medicalRecord.AllergiesListToString(medicalRecord.Allergy)
            };

            return dto;
        }

        private static string GetSelectedDoctorsName(Patient patient)
        {
            if (patient.SelectedDoctor == null) return "";
            return patient.SelectedDoctor.FullName;
        }
    }
}
