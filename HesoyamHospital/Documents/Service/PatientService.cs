using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Documents.Repository;
using Documents.Service.Abstract;
using System.Collections.Generic;

namespace Documents.Service
{
    public class PatientService : IPatientService
    {
        readonly PatientRepository _patientRepository;
        readonly DoctorRepository _doctorRepository;
        readonly MedicalRecordRepository _medicalRecordRepository;

        public PatientService(PatientRepository patientRepository, MedicalRecordRepository medicalRecordRepository, DoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAll();

        public Patient GetByID(long id)
            => _patientRepository.GetByID(id);

        public Patient GetByUsername(string username)
            => _patientRepository.GetPatientByUsername(username);

        public Patient Create(Patient entity)
        {
            Patient patient = _patientRepository.Create(entity);
            _medicalRecordRepository.Create(new MedicalRecord(patient));
            return patient;
        }

        public Patient ChangeSelectedDoctor(long doctorId, long patientId)
        {
            Patient patient = _patientRepository.GetByID(patientId);
            Doctor selectedDoctor = _doctorRepository.GetByID(doctorId);
            if (patient == null || selectedDoctor == null) return null;
            patient.SelectedDoctor = selectedDoctor;
            _patientRepository.Update(patient);
            return patient;
        }

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Update(Patient entity)
            => _patientRepository.Update(entity);
    }
}
