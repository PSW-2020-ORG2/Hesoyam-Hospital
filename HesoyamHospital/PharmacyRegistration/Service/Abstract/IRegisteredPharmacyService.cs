using PharmacyRegistration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Service.Abstract
{
    public interface IRegisteredPharmacyService : IService<RegisteredPharmacy, long>
    {
        public RegisteredPharmacy GetRegisteredPharmacyByName(string name);
    }
}
