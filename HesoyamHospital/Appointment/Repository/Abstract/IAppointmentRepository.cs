using Backend.Model.PatientModel;

namespace Appointments.Repository.Abstract
{
    public interface IAppointmentRepository : IRepository<Appointment, long>
    {
    }
}
