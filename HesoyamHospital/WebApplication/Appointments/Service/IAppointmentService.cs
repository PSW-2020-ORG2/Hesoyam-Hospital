using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Service;
using System.Collections.Generic;

namespace WebApplication.Appointments.Service
{
    public interface IAppointmentService : IService<Appointment, long>
    {
        public IEnumerable<Appointment> GetAllByPatient(long patientId);
        public void DeactivateFillingOutSurvey(long appointmentId);
        public Doctor GetDoctorAtAppointment(long appointmentId);
        public void Cancel(long patientId, long appointmentId);
        public List<Patient> GetSuspiciousPatients();
        public Patient BlockPatient(string username);
    }
}
