using MedicineProcurement.Model;
using System.Collections.Generic;

namespace MedicineProcurement.Repository.Abstract
{
    public interface ITenderOfferRepository : IRepository<TenderOffer, long>
    {
        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id);
        public IEnumerable<string> GetAllOfferEmails(long id);
    }
}
