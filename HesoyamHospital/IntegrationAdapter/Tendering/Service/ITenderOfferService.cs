using Backend.Model.PharmacyModel;
using Backend.Service;
using System.Collections.Generic;

namespace IntegrationAdapter.Tendering.Service
{
    public interface ITenderOfferService : IService<TenderOffer, long>
    {
        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id);
        public IEnumerable<string> GetAllOfferEmails(long id);
    }
}
