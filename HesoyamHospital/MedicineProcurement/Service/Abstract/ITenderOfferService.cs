using MedicineProcurement.Model;
using System.Collections.Generic;

namespace MedicineProcurement.Service.Abstract
{
    public interface ITenderOfferService : IService<TenderOffer, long>
    {
        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id);
        public IEnumerable<string> GetAllOfferEmails(long id);
    }
}
