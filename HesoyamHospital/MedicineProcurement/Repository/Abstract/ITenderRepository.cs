using MedicineProcurement.Model;
using System.Collections.Generic;

namespace MedicineProcurement.Repository.Abstract
{
    public interface ITenderRepository : IRepository<Tender, long>
    {
        public IEnumerable<Tender> GetAllActiveTenders();
        public IEnumerable<Tender> GetAllUnconcludedTenders();
    }
}
