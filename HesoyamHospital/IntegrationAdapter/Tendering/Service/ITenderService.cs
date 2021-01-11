using Backend.Model.PharmacyModel;
using Backend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAdapter.Tendering.Service
{
    public interface ITenderService : IService<Tender, long>
    {
        public IEnumerable<Tender> GetAllActiveTenders();
        public IEnumerable<Tender> GetAllUnconcludedTenders();
        public void ConcludeTender(long tenderId, long winnerOfferId, List<string> allEmails);
    }
}
