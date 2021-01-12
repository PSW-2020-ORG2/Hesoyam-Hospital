using MedicineProcurement.Exceptions;
using MedicineProcurement.Model;
using MedicineProcurement.Repository.Abstract;
using MedicineProcurement.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Service
{
    public class TenderOfferService : ITenderOfferService
    {
        private readonly ITenderOfferRepository _tenderOfferRepository;
        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
        }
        public TenderOffer Create(TenderOffer entity)
        {
            Validate(entity);
            return _tenderOfferRepository.Create(entity);
        }

        public void Delete(TenderOffer entity)
        {
            _tenderOfferRepository.Delete(entity);
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _tenderOfferRepository.GetAll();
        }

        public IEnumerable<string> GetAllOfferEmails(long id)
        {
            return _tenderOfferRepository.GetAllOfferEmails(id);
        }

        public TenderOffer GetByID(long id)
        {
            return _tenderOfferRepository.GetByID(id);
        }

        public IEnumerable<TenderOffer> GetTenderOffersForTender(long id)
        {
            return _tenderOfferRepository.GetTenderOffersForTender(id);
        }

        public void Update(TenderOffer entity)
        {
            Validate(entity);
            _tenderOfferRepository.Update(entity);
        }

        public void Validate(TenderOffer entity)
        {
            foreach (TenderOfferListing listing in entity.TenderOfferListings)
            {
                if (listing.UnitPrice < 0)
                {
                    throw new InvalidPriceException("Unit price cannot be less than 0!");
                }
            }
        }
    }
}
