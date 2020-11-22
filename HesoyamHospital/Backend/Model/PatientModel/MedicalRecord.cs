// File:    MedicalRecord.cs
// Author:  Windows 10
// Created: 15. april 2020 21:34:36
// Purpose: Definition of Class MedicalRecord

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;
using Backend.Model.UserModel;

namespace Backend.Model.PatientModel
{
    public class MedicalRecord : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private BloodType _patientBloodType;
        public BloodType PatientBloodType { get => _patientBloodType; set => _patientBloodType = value; }

        private Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        private long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        private List<Report> _patientReports;
        private List<Allergy> _allergy;
        private List<Prescription> _prescriptions;


        public List<Report> PatientReports
        {
            get
            {
                if (_patientReports == null)
                    _patientReports = new List<Report>();
                return _patientReports;
            }
            set
            {
                RemoveAllPatientReport();
                if (value != null)
                {
                    foreach (Report oReport in value)
                        AddPatientReport(oReport);
                }
            }
        }

        public List<Allergy> Allergy
        {
            get
            {
                if (_allergy == null)
                    _allergy = new List<Allergy>();
                return _allergy;
            }
            set
            {
                RemoveAllAllergy();
                if (value != null)
                {
                    foreach (Allergy oAllergy in value)
                        AddAllergy(oAllergy);
                }
            }
        }

        public List<Prescription> Prescriptions
        {
            get
            {
                if (_prescriptions == null)
                    _prescriptions = new List<Prescription>();
                return _prescriptions;
            }
            set
            {
                RemoveAllAllergy();
                if (value != null)
                {
                    foreach (Prescription oPrescription in value)
                        AddPrescription(oPrescription);
                }
            }
        }

        public MedicalRecord(long id)
        {
            _id = id;
            
        }

        public MedicalRecord(Patient patient)
        {
            _patient = patient;
            _patientID = patient.Id;
            _patientBloodType = BloodType.NOT_TESTED;
            _patientReports = new List<Report>();
            _allergy = new List<Allergy>();
        }

        public MedicalRecord(Patient patient, BloodType bloodType)
        {
            _patient = patient;
            _patientBloodType = bloodType;
            _patientReports = new List<Report>();
            _allergy = new List<Allergy>();
            _patientID = patient.Id;
        }

        public MedicalRecord(Patient patient, BloodType bloodType, List<Report> patientReport, List<Allergy> patientAllergies)
        {
            _patient = patient;
            _patientBloodType = bloodType;
            _patientReports = patientReport;
            _allergy = patientAllergies;
            _patientID = patient.Id;
        }

        public MedicalRecord(long id, Patient patient, BloodType bloodType, List<Report> patientReport, List<Allergy> patientAllergies)
        {
            _id = id;
            _patient = patient;
            _patientBloodType = bloodType;
            _patientReports = patientReport;
            _allergy = patientAllergies;
            _patientID = patient.Id;
        }

        public long GetId()
        => _id;

        public void SetId(long id)
            => _id = id;


        public void AddPatientReport(Report newReport)
        {
            if (newReport == null)
                return;
            if (_patientReports == null)
                _patientReports = new List<Report>();
            if (!_patientReports.Contains(newReport))
                _patientReports.Add(newReport);
        }

        public void RemovePatientReport(Report oldReport)
        {
            if (oldReport == null)
                return;
            if (_patientReports != null)
                if (_patientReports.Contains(oldReport))
                    _patientReports.Remove(oldReport);
        }

        public void RemoveAllPatientReport()
        {
            if (_patientReports != null)
                _patientReports.Clear();
        }
        
        public void AddAllergy(Allergy newAllergy)
        {
            if (newAllergy == null)
                return;
            if (_allergy == null)
                _allergy = new List<Allergy>();
            if (!_allergy.Contains(newAllergy))
                _allergy.Add(newAllergy);
        }

        public void RemoveAllergy(Allergy oldAllergy)
        {
            if (oldAllergy == null)
                return;
            if (_allergy != null)
                if (_allergy.Contains(oldAllergy))
                    _allergy.Remove(oldAllergy);
        }

        public void RemoveAllAllergy()
        {
            if (_allergy != null)
                _allergy.Clear();
        }

        public void AddPrescription(Prescription newPrescription)
        {
            if (newPrescription == null)
                return;
            if (_prescriptions == null)
                _prescriptions = new List<Prescription>();
            if (!_prescriptions.Contains(newPrescription))
                _prescriptions.Add(newPrescription);
        }

        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (_prescriptions != null)
                if (_prescriptions.Contains(oldPrescription))
                    _prescriptions.Remove(oldPrescription);
        }

        public void RemoveAllPrescription()
        {
            if (_prescriptions != null)
                _prescriptions.Clear();
        }


        public override bool Equals(object obj)
        {
            var record = obj as MedicalRecord;
            return record != null &&
                   _id == record._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

    }
}