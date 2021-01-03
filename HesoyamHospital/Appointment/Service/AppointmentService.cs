using Appointments.DTOs;
using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Appointments.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICancellationRepository _cancellationRepository;
        private readonly int CANCELLATION_COUNT = 3;

        public AppointmentService(IAppointmentRepository appointmentRepository, ICancellationRepository cancellationRepository)
        {
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

        public List<BlockPatientDTO> GetSuspiciousPatients(IHttpRequestSender httpRequestSender)
        {
            Dictionary<long, int> cancellationCounts = _cancellationRepository.GetCancelledCountForPatients();
            if (cancellationCounts.Count == 0) return new List<BlockPatientDTO>();
            return PatientsWithMultipleCancellations(cancellationCounts, httpRequestSender);
        }

        public List<BlockPatientDTO> PatientsWithMultipleCancellations(Dictionary<long, int> cancellationCounts, IHttpRequestSender httpRequestSender)
        {
            List<BlockPatientDTO> suspiciousPatients = new List<BlockPatientDTO>();
            foreach (var item in cancellationCounts)
            {
                if (item.Value >= CANCELLATION_COUNT) 
                    suspiciousPatients.Add(new BlockPatientDTO(httpRequestSender.GetPatientUsername(item.Key),
                                                               item.Value,
                                                               httpRequestSender.GetPatientFullName(item.Key),
                                                               httpRequestSender.IsBlocked(item.Key)));
            }
            return suspiciousPatients;
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
            => _appointmentRepository.GetAll().Where(a => a.PatientId == patientId);

        public Appointment GetByID(long id)
            => _appointmentRepository.GetByID(id);

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public bool SurveyCanBeFilledOut(long appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetByID(appointmentId);
            return appointment.AbleToFillOutSurvey && !appointment.Canceled && appointment.TimeInterval.IsInThePast();
        }

        public long GetDoctorInAppointmentId(long appointmentId)
            => _appointmentRepository.GetByID(appointmentId).DoctorInAppointmentId;
    }
}
