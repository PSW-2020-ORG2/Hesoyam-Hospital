using Backend.Model.PharmacyModel;
using Backend.Repository.Abstract.MiscAbstractRepository;
using Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Backend.Service.MiscService
{
    public class RegisteredPharmacyService : IService<RegisteredPharmacy, long>
    {
        private IRegisteredPharmacyRepository _registeredPharmacyRepository;

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

        private RegisteredPharmacy GetRegisteredPharmacyByName(string name)
        {
            return _registeredPharmacyRepository.GetRegisteredPharmacyByName(name);
        }

        private bool IsPharmacyRegistered(string name) =>  GetRegisteredPharmacyByName(name) != null ? true : false;

        private bool IsEndpointValid(string endpoint)
        {
            Regex endpointRegex = new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$");
            return endpointRegex.IsMatch(endpoint);
        }

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
            if (!IsEndpointValid(entity.Endpoint))
            {
                throw new InvalidRegisteredPharmacyEndpointException("Invalid endpoint.");
            }
        }
    }
}
