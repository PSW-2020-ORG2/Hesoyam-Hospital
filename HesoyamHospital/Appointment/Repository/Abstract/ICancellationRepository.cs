using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace Appointments.Repository.Abstract
{
    public interface ICancellationRepository : IRepository<Cancellation, long>
    {
        public Dictionary<long, int> GetCancelledCountForPatients();
    }
}
