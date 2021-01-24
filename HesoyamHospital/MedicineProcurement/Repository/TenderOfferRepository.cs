using MedicineProcurement.Model;
using MedicineProcurement.Repository.Abstract;
using MedicineProcurement.Repository.SQLRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Repository
{
    public class TenderOfferRepository : SQLRepository<TenderOffer, long>, ITenderOfferRepository
    {
        public TenderOfferRepository(SQLStream<TenderOffer> stream) : base(stream)
        {
        }

        public IEnumerable<string> GetAllOfferEmails(long id)
            => GetAll().Where(tenderOffer => tenderOffer.TenderId == id).Select(offer => offer.Email);
        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id)
            => GetAll().Where(tenderOffer => id == tenderOffer.TenderId);
    }
}
