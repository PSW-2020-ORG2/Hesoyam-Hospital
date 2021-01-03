using Appointments.DTOs;
using Appointments.Model;
using System.Collections.Generic;

namespace Appointments.Service.Abstract
{
    public interface IAppointmentService : IService<Appointment, long>
    {
        public IEnumerable<Appointment> GetAllByPatient(long patientId);
        public void DeactivateFillingOutSurvey(long appointmentId);
        public void Cancel(long patientId, long appointmentId);
        public List<BlockPatientDTO> GetSuspiciousPatients(IHttpRequestSender httpRequestSender);
        public bool SurveyCanBeFilledOut(long appointmentId);
        public long GetDoctorInAppointmentId(long appointmentId);
    }
}
