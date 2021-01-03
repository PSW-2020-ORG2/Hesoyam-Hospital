using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;

namespace Appointments.Repository
{
    public class AppointmentRepository : SQLRepository<Appointment, long>, IAppointmentRepository
    {
        public AppointmentRepository(ISQLStream<Appointment> stream) : base(stream)
        {
        }
    }
}
