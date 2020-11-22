using Backend.Model.UserModel;
using Backend.Repository.Abstract;
using System;
namespace Backend.Model.PatientModel
{
    public class Report : Document, IIdentifiable<long>
    {
        private string _comment;
        public string Comment { get => _comment; set => _comment = value; }

        public Report (long id)
        {
            _id = id;
            _dateCreated = DateTime.Now;
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
