using Backend.Model.PatientModel;
using Backend.Model.UserModel;

namespace Feedbacks.Service.Abstract
{
    public interface IAppointmentService : IService<Appointment, long>
    {
        public void DeactivateFillingOutSurvey(long appointmentId);
        public Doctor GetDoctorAtAppointment(long appointmentId);
    }
}
