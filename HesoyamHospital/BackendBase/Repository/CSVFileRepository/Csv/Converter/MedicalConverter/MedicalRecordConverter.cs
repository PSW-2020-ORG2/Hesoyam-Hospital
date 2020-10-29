// File:    MedicalRecordConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:28
// Purpose: Definition of Class MedicalRecordConverter

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class MedicalRecordConverter : ICSVConverter<MedicalRecord>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";

        public MedicalRecordConverter()
        {
        }

        public MedicalRecord ConvertCSVToEntity(string medicalRecordCSVformat)
        {
            string[] tokens = SplitStringByDelimiter(medicalRecordCSVformat, _delimiter);
            return new MedicalRecord(long.Parse(tokens[0]),
                                     new Patient(new UserID(tokens[1])),
                                     (BloodType)Enum.Parse(typeof(BloodType), tokens[2]),
                                     tokens[3] == "" ? new List<Diagnosis>() : GetDiagnosisCSVlist(SplitStringByDelimiter(tokens[3],_listDelimiter)),
                                     tokens[4] == "" ? new List<Allergy>() : GetAllergyCSVlist(SplitStringByDelimiter(tokens[4], _listDelimiter))
                                     );
        }

        public string ConvertEntityToCSV(MedicalRecord medicalRecord)
            => string.Join(_delimiter,
                           medicalRecord.GetId(),
                           medicalRecord.Patient.GetId(),
                           medicalRecord.PatientBloodType,
                           GetDiagnosisCSVstring(medicalRecord.PatientDiagnosis),
                           GetPatientAllergyCSVstring(medicalRecord.Allergy));


        private string GetDiagnosisCSVstring(List<Diagnosis> diagnosis)
            => string.Join(_listDelimiter, diagnosis.Select(_patientDiagnosis => _patientDiagnosis.GetId()));

        private string GetPatientAllergyCSVstring(List<Allergy> allergies)
            => string.Join(_listDelimiter, allergies.Select(_allergy => _allergy.GetId()));

        private List<Diagnosis> GetDiagnosisCSVlist(string[] ids)
            => ids.ToList().ConvertAll(x => new Diagnosis(long.Parse(x)));

        private List<Allergy> GetAllergyCSVlist(string[] ids)
            => ids.ToList().ConvertAll(x => new Allergy(long.Parse(x)));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
          => stringToSplit.Split(delimiter.ToCharArray());
    }
}