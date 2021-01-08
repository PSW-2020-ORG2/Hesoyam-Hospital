using Backend.Model.PharmacyModel;
using System.Collections.Generic;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface ITenderOfferRepository : IRepository<TenderOffer, long>
    {
        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id);
    }
}
