using Appointments.Model;
using Appointments.Repository.Abstract;
using Appointments.Repository.SQLRepository.Base;

namespace Appointments.Repository
{
    public class TimeTableRepository : SQLRepository<TimeTable, long>, ITimeTableRepository
    {
        public TimeTableRepository(ISQLStream<TimeTable> stream) : base(stream)
        {
        }
    }
}
