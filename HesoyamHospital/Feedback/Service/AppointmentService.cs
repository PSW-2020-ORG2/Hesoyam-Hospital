using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Service.Abstract;
using System;
using System.Collections.Generic;

namespace Feedbacks.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void DeactivateFillingOutSurvey(long appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetByID(appointmentId);
            appointment.AbleToFillOutSurvey = false;
            _appointmentRepository.UpdateProperty(appointment, "AbleToFillOutSurvey");
        }

        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(long id)
            => _appointmentRepository.GetByID(id);

        public Doctor GetDoctorAtAppointment(long appointmentId)
            => _appointmentRepository.GetByID(appointmentId).DoctorInAppointment;

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
