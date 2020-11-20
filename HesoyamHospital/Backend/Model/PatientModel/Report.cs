using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using System;
namespace Backend.Model.PatientModel
{
    public class Report : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private Patient _patient;
        public Patient Patient { get => _patient; set { _patient = value; _patientID = value.Id; } }

        private long _patientID;
        public long PatientID { get => _patientID; set => _patientID = value; }

        private Doctor _doctor;
        public Doctor Doctor { get => _doctor; set { _doctor = value; _doctorID = value.Id; } }

        private long _doctorID;
        public long DoctorID { get => _doctorID; set => _doctorID = value; }

        private DateTime _dateTimeCreated;
        public DateTime DateTimeCreated { get => _dateTimeCreated; set => _dateTimeCreated = value; }

        private string _comment;
        public string Comment { get => _comment; set => _comment = value; }

        private Diagnosis _diagnosis;
        public Diagnosis Diagnosis { get => _diagnosis; set { _diagnosis = value; _diagnosisID = value.Id; } }

        private long _diagnosisID;
        public long DiagnosisID { get => _diagnosisID; set => _diagnosisID = value; }

        public Report (long id)
        {
            _id = id;
            DateTimeCreated = DateTime.Now;
        }

        public Report (long id, Patient patient, Doctor doctor, string comment, Diagnosis diagnosis)
        {
            _id = id;
            _patient = patient;
            _patientID = patient.Id;
            _doctor = doctor;
            _doctorID = doctor.Id;
            _comment = comment;
            _diagnosis = diagnosis;
            _diagnosisID = diagnosis.Id;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var report = obj as Report;
            return report != null &&
                   _id == report._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}
