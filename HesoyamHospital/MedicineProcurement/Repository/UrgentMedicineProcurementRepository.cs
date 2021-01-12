using MedicineProcurement.Model;
using MedicineProcurement.Repository.Abstract;
using MedicineProcurement.Repository.SQLRepository.Base;
using System.Collections.Generic;
using System.Linq;

namespace MedicineProcurement.Repository
{
    public class UrgentMedicineProcurementRepository : SQLRepository<UrgentMedicineProcurement, long>, IUrgentMedicineProcurementRepository
    {
        public UrgentMedicineProcurementRepository(ISQLStream<UrgentMedicineProcurement> stream) : base(stream)
        {
        }

        public IEnumerable<UrgentMedicineProcurement> GetAllUnconcluded()
            => GetAll().Where(medicine => medicine.Concluded == false);
    }
}
