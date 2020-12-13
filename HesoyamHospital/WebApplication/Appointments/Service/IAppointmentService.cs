using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service;
using System.Collections.Generic;
using WebApplication.Appointments.DTOs;

namespace WebApplication.Appointments.Service
{
    public interface IAppointmentService : IService<Appointment, long>
    {
        public IEnumerable<Appointment> GetAllByPatient(long patientId);
        public void DeactivateFillingOutSurvey(long appointmentId);
        public Doctor GetDoctorAtAppointment(long appointmentId);
        public void Cancel(long patientId, long appointmentId);
        public List<BlockPatientDTO> GetSuspiciousPatients();
        public Patient BlockPatient(Patient patient);
    }
}
