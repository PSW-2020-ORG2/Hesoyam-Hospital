using Appointments.Model;

namespace Appointments.Repository.Abstract
{
    public interface IAppointmentRepository : IRepository<Appointment, long>
    {
    }
}
