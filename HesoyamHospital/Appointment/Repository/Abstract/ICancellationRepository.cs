using Appointments.Model;
using System.Collections.Generic;

namespace Appointments.Repository.Abstract
{
    public interface ICancellationRepository : IRepository<Cancellation, long>
    {
        public Dictionary<long, int> GetCancelledCountForPatients();
    }
}
