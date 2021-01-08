using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.Tendering.Service
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
            foreach(TenderOfferListing listing in entity.TenderOfferListings)
            {
                if(listing.UnitPrice < 0)
                {
                    throw new InvalidPriceException("Unit price cannot be less than 0!");
                }
            }
        }
    }
}
