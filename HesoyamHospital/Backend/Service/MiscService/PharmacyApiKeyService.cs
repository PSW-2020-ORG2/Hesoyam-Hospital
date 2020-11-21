using Backend.Model.PharmacyModel;
using Backend.Repository.MySQLRepository.MiscRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.MiscService
{
    public class PharmacyApiKeyService : IService<RegisteredPharmacy, long>
    {
        private RegisteredPharmacyRepository _pharmacyApiKeyRepository;

        public PharmacyApiKeyService(RegisteredPharmacyRepository pharmacyApiKeyRepository)
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
