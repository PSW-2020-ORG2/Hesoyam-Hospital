using MedicineProcurement.Model;
using MedicineProcurement.Service.Abstract;
using System.Collections.Generic;

namespace MedicineProcurement.Service.Abstract
{
    public interface ITenderService : IService<Tender, long>
    {
        public IEnumerable<Tender> GetAllActiveTenders();
        public IEnumerable<Tender> GetAllUnconcludedTenders();
        public void ConcludeTender(long tenderId, long winnerOfferId, List<string> allEmails);
    }
}
