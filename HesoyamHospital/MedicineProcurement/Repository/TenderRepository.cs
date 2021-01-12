using MedicineProcurement.Model;
using MedicineProcurement.Repository.SQLRepository.Base;
using MedicineProcurement.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace MedicineProcurement.Repository
{
    public class TenderRepository : SQLRepository<Tender, long>, ITenderRepository
    {
        public TenderRepository(ISQLStream<Tender> stream) : base(stream)
        {
        }

        public IEnumerable<Tender> GetAllActiveTenders()
            => GetAll().Where(tender => tender.IsActive() == true);
        public IEnumerable<Tender> GetAllUnconcludedTenders()
            => GetAll().Where(tender => tender.Concluded == false && tender.IsActive() == false);
    }
}
