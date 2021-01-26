using PharmacyRegistration.Model;
using PharmacyRegistration.Repository.Abstract;
using PharmacyRegistration.Repository.SQLRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Repository
{
    public class RegisteredPharmacyRepository : SQLRepository<RegisteredPharmacy, long>, IRegisteredPharmacyRepository
    {
        public RegisteredPharmacyRepository(ISQLStream<RegisteredPharmacy> stream) : base(stream)
        {
        }
        public RegisteredPharmacy GetRegisteredPharmacyByName(string pharmacyName)
            => GetAll().SingleOrDefault(pharmacy => pharmacy.PharmacyName.Equals(pharmacyName));
    }
}
