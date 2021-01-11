using Backend.Model.PharmacyModel;
using System.Collections.Generic;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface ITenderRepository : IRepository<Tender, long>
    {
        public IEnumerable<Tender> GetAllActiveTenders();
        public IEnumerable<Tender> GetAllUnconcludedTenders();
    }
}
