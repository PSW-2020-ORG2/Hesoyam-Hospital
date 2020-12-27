using Appointments.Model.ScheduleModel;

namespace Appointments.Repository.Abstract
{
    public interface IAppointmentRepository : IRepository<Appointment, long>
    {
    }
}
