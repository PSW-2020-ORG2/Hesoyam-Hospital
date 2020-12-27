using Authentication.Model.ScheduleModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Repository.SQLRepository.Base;

namespace Feedbacks.Repository
{
    public class AppointmentRepository : SQLRepository<Appointment, long>, IAppointmentRepository
    {
        public AppointmentRepository(ISQLStream<Appointment> stream) : base(stream)
        {
        }
    }
}
