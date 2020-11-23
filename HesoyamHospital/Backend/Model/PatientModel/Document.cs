using Backend.Model.UserModel;
using Backend.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PatientModel
{
    public class Document
    {
        protected long _id;
        public long Id { get => _id; set => _id = value; }

        protected DateTime _dateCreated;
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }

        protected Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        protected long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        protected Doctor _doctor;
        public Doctor Doctor { get => _doctor; set { _doctor = value; _doctorID = value.Id; } }

        protected long _doctorID;
        public long DoctorID { get => _doctorID; set => _doctorID = value; }

        protected Diagnosis _diagnosis;
        public Diagnosis Diagnosis { get => _diagnosis; set { _diagnosis = value; _diagnosisID = value.Id; } }

        protected long _diagnosisID;
        public long DiagnosisID { get => _diagnosisID; set => _diagnosisID = value; }

        public Document() { }

        public virtual bool meetsCriteria(DocumentSearchCriteria criteria)
        {
            if (!_doctor.FullName.ToLower().Contains(criteria.DoctorName.ToLower())) return false;
            if (!_diagnosis.diagnosisName.ToLower().Contains(criteria.DiagnosisName.ToLower())) return false;
            if (!criteria.TimeInterval.IsDateTimeBetween(_dateCreated)) return false;
            return true;
        }
    }
}
