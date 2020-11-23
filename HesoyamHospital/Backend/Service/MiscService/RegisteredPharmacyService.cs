using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using System;
using System.Collections.Generic;

namespace Backend.Service.MiscService
{
    public class RegisteredPharmacyService : IService<RegisteredPharmacy, long>
    {
        private IRegisteredPharmacyRepository _pharmacyApiKeyRepository;

        public RegisteredPharmacyService(IRegisteredPharmacyRepository pharmacyApiKeyRepository)
        {
            _pharmacyApiKeyRepository = pharmacyApiKeyRepository;
        }
        public RegisteredPharmacy Create(RegisteredPharmacy entity)
        {
            return _pharmacyApiKeyRepository.Create(entity);
        }

        public void Delete(RegisteredPharmacy entity)
        {
            _pharmacyApiKeyRepository.Delete(entity);
        }

        public IEnumerable<RegisteredPharmacy> GetAll()
        {
            return _pharmacyApiKeyRepository.GetAll();
        }

        public RegisteredPharmacy GetByID(long id)
        {
            return _pharmacyApiKeyRepository.GetByID(id);
        }

        public RegisteredPharmacy GetRegisteredPharmacyByName(string name)
        {
            return _pharmacyApiKeyRepository.GetRegisteredPharmacyByName(name);
        }

        public void Update(RegisteredPharmacy entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(RegisteredPharmacy entity)
        {
            throw new NotImplementedException();
        }
    }
}
