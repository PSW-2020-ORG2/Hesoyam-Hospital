using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Appointments.DTOs;

namespace WebApplication.Appointments.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICancellationRepository _cancellationRepository;
        private readonly int CANCELLATION_COUNT = 3;

        public AppointmentService(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository, ICancellationRepository cancellationRepository)
        {
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
            _cancellationRepository = cancellationRepository;
        }

        public void Cancel(long patientId, long appointmentId)
        {
            Appointment appointment = GetByID(appointmentId);
            appointment.Canceled = true;
            _appointmentRepository.Update(appointment);
            SaveCancellationData(appointment);
        }

        private void SaveCancellationData(Appointment appointment)
        {
            _cancellationRepository.Create(new Cancellation(0, appointment, DateTime.Now));
        }

        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void DeactivateFillingOutSurvey(long appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetByID(appointmentId);
            appointment.AbleToFillOutSurvey = false;
            _appointmentRepository.UpdateProperty(appointment, "AbleToFillOutSurvey");
        }

        public List<BlockPatientDTO> GetSuspiciousPatients()
        {
            Dictionary<long, int> cancellationCounts = _cancellationRepository.GetCancelledCountForPatients();
            if (cancellationCounts.Count == 0) return null;
            return PatientsWithMultipleCancellations(cancellationCounts);
        }

        public List<BlockPatientDTO> PatientsWithMultipleCancellations(Dictionary<long, int> cancellationCounts)
        {
            List<BlockPatientDTO> suspiciousPatients = new List<BlockPatientDTO>();
            foreach (var item in cancellationCounts)
            {
                Patient patient = _patientRepository.GetByID(item.Key);
                if (patient == null) break;
                if (item.Value >= CANCELLATION_COUNT) suspiciousPatients.Add(new BlockPatientDTO(patient.UserName, item.Value, patient.FullName));
            }
            return suspiciousPatients;
        }

        public Patient BlockPatient(Patient patient)
        {
            patient.Blocked = true;
            _patientRepository.Update(patient);
            return patient;
        } 

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAllByPatient(long patientId)
            => _patientRepository.GetByID(patientId).Appointments;

        public Appointment GetByID(long id)
            => _appointmentRepository.GetByID(id);

        public Doctor GetDoctorAtAppointment(long appointmentId)
            => _appointmentRepository.GetByID(appointmentId).DoctorInAppointment;

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
