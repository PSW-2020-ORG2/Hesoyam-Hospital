using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;
using Backend.Model.PatientModel;

namespace Appointments.Repository
{
    public class AppointmentRepository : SQLRepository<Appointment, long>, IAppointmentRepository
    {
        public AppointmentRepository(ISQLStream<Appointment> stream) : base(stream)
        {
        }
    }
}
