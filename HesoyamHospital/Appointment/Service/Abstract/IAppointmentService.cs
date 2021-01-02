using Appointments.DTOs;
using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Appointments.Service.Abstract
{
    public interface IAppointmentService : IService<Appointment, long>
    {
        public IEnumerable<Appointment> GetAllByPatient(long patientId);
        public void DeactivateFillingOutSurvey(long appointmentId);
        public Doctor GetDoctorAtAppointment(long appointmentId);
        public void Cancel(long patientId, long appointmentId);
        public List<BlockPatientDTO> GetSuspiciousPatients();
        public Patient BlockPatient(Patient patient);
        public bool SurveyCanBeFilledOut(long appointmentId);
        public long GetDoctorInAppointmentId(long appointmentId);
    }
}
