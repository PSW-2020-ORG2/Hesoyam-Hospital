using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace Backend.Repository.Abstract.MedicalAbstractRepository
{
    public interface ICancellationRepository : IRepository<Cancellation, long>
    {
        public Dictionary<long, int> GetCancelledCountForPatients();
    }
}
