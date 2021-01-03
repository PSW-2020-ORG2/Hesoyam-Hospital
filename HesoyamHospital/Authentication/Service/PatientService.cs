using Authentication.Model.MedicalRecordModel;
using Authentication.Model.UserModel;
using Authentication.Repository;
using Authentication.Service.Abstract;
using System.Collections.Generic;

namespace Authentication.Service
{
    public class PatientService : IPatientService
    {
        readonly PatientRepository _patientRepository;
        readonly MedicalRecordRepository _medicalRecordRepository;
        readonly DoctorRepository _doctorRepository;

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

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Update(Patient entity)
            => _patientRepository.Update(entity);

        public long GetTimeTableForSelectedDoctor(long id)
            => _patientRepository.GetByID(id).SelectedDoctor.TimeTable.Id;

        public long GetSelectedDoctor(long id)
            => _patientRepository.GetByID(id).SelectedDoctor.Id;

        public Patient Activate(long id)
        {
            Patient patient = _patientRepository.GetByID(id);
            if (patient == null) return null;
            patient.Active = true;
            _patientRepository.Update(patient);
            return patient;
        }

        public Patient BlockPatient(Patient patient)
        {
            patient.Blocked = true;
            _patientRepository.Update(patient);
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

        public string GetUsername(long id)
            => _patientRepository.GetByID(id).UserName;

        public string GetFullName(long id)
            => _patientRepository.GetByID(id).FullName;

        public bool IsBlocked(long id)
            => _patientRepository.GetByID(id).Blocked;
    }
}
