using PharmacyRegistration.Exceptions;
using PharmacyRegistration.Model;
using PharmacyRegistration.Repository.Abstract;
using PharmacyRegistration.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Service
{
    public class RegisteredPharmacyService : IRegisteredPharmacyService
    {
        private readonly IRegisteredPharmacyRepository _registeredPharmacyRepository;

        public RegisteredPharmacyService(IRegisteredPharmacyRepository registeredPharmacyRepository)
        {
            _registeredPharmacyRepository = registeredPharmacyRepository;
        }
        public RegisteredPharmacy Create(RegisteredPharmacy entity)
        {
            Validate(entity);
            return _registeredPharmacyRepository.Create(entity);
        }

        public void Delete(RegisteredPharmacy entity)
        {
            _registeredPharmacyRepository.Delete(entity);
        }

        public IEnumerable<RegisteredPharmacy> GetAll()
        {
            return _registeredPharmacyRepository.GetAll();
        }

        public RegisteredPharmacy GetByID(long id)
        {
            return _registeredPharmacyRepository.GetByID(id);
        }

        public RegisteredPharmacy GetRegisteredPharmacyByName(string name)
        {
            return _registeredPharmacyRepository.GetRegisteredPharmacyByName(name);
        }

        private bool IsPharmacyRegistered(string name) => GetRegisteredPharmacyByName(name) != null ? true : false;

        public void Update(RegisteredPharmacy entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(RegisteredPharmacy entity)
        {
            if (IsPharmacyRegistered(entity.PharmacyName))
            {
                throw new RegisteredPharmacyNameNotUniqueException("Pharmacy with name " + entity.PharmacyName + " already exists.");
            }
        }
    }
}
