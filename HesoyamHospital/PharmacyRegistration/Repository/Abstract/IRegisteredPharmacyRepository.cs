using PharmacyRegistration.Model;

namespace PharmacyRegistration.Repository.Abstract
{
    public interface IRegisteredPharmacyRepository : IRepository<RegisteredPharmacy, long>
    {
        RegisteredPharmacy GetRegisteredPharmacyByName(string pharmacyName);
    }
}
