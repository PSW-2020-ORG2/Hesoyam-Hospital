// File:    Prescription.cs
// Author:  nikola
// Created: 21. maj 2020 15:43:46
// Purpose: Definition of Class Prescription

using Backend.Repository.Abstract;
using System.Collections.Generic;
using Backend.Model.UserModel;
using System;

namespace Backend.Model.PatientModel
{
    public class Prescription : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private PrescriptionStatus _status;
        public PrescriptionStatus Status { get => _status; set => _status = value; }

        private DateTime _dateCreated;
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }

        private Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        private long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        private Doctor _doctor;
        public Doctor Doctor { get => _doctor; set { _doctor = value; _doctorID = value.Id; } }

        private long _doctorID;
        public long DoctorID { get => _doctorID; set => _doctorID = value; }

        private Diagnosis _diagnosis;
        public Diagnosis Diagnosis { get => _diagnosis; set { _diagnosis = value; _diagnosisID = value.Id; } }

        private long _diagnosisID;
        public long DiagnosisID { get => _diagnosisID; set => _diagnosisID = value; }

        private List<MedicalTherapy> _medicalTherapies;
        public List<MedicalTherapy> MedicalTherapies
        {
            get
            {
                if (_medicalTherapies == null)
                    _medicalTherapies = new List<MedicalTherapy>();
                return _medicalTherapies;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (MedicalTherapy mt in value)
                        AddMedicine(mt);
                }
            }
        }

        public Prescription(long id)
        {
            _id = id;
        }
        public Prescription(long id, PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            _id = id;
            _status = status;
            _doctor = doctor;
            _medicalTherapies = medicalTherapies;
            _doctorID = doctor.Id;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies)
        {
            _status = status;
            _doctor = doctor;
            _medicalTherapies = medicalTherapies;
            _doctorID = doctor.Id;
        }

        public Prescription(List<MedicalTherapy> medicalTherapies)
        {
            _status = PrescriptionStatus.ACTIVE;
            _medicalTherapies = medicalTherapies;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor, List<MedicalTherapy> medicalTherapies, Diagnosis diagnosis, Patient patient)
        {
            _status = status;
            _doctor = doctor;
            _medicalTherapies = medicalTherapies;
            _doctorID = doctor.Id;
            _diagnosis = diagnosis;
            _diagnosisID = diagnosis.Id;
            _patient = patient;
            _patientID = patient.Id;
        }

        public void AddMedicine(MedicalTherapy mt)
      {
         if (mt == null)
            return;
         if (this._medicalTherapies == null)
            this._medicalTherapies = new List<MedicalTherapy>();
         if (!this._medicalTherapies.Contains(mt))
            this._medicalTherapies.Add(mt);
      }
      
      public void RemoveMedicine(MedicalTherapy mt)
      {
         if (mt == null)
            return;
         if (this._medicalTherapies != null)
            if (this._medicalTherapies.Contains(mt))
               this._medicalTherapies.Remove(mt);
      }
      
      public void RemoveAllMedicine()
      {
         if (_medicalTherapies != null)
            _medicalTherapies.Clear();
      }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            var prescription = obj as Prescription;
            return prescription != null &&
                   _id == prescription._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}