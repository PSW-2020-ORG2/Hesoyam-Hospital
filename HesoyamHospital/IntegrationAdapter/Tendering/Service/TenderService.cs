using Backend.Exceptions;
using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.Tendering.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }
        public Tender Create(Tender entity)
        {
            Validate(entity);
            return _tenderRepository.Create(entity);
        }

        public void Delete(Tender entity)
        {
            _tenderRepository.Delete(entity);
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public IEnumerable<Tender> GetAllActiveTenders()
        {
            return _tenderRepository.GetAllActiveTenders();
        }

        public Tender GetByID(long id)
        {
            return _tenderRepository.GetByID(id);
        }

        public void Update(Tender entity)
        {
            Validate(entity);
            _tenderRepository.Update(entity);
        }

        public void Validate(Tender entity)
        {
            if(entity.EndDate == null)
            {
                throw new NullDateException("Tender end date cannot be null!");
            }
            if(entity.EndDate < DateTime.Now)
            {
                throw new InvalidDateException("Tender end date must be in the future!");
            }
            if(entity.TenderListings.Count == 0 || entity.TenderListings == null)
            {
                throw new TenderListingsEmptyException("Tender must contain listings!");
            }
        }
    }
}
