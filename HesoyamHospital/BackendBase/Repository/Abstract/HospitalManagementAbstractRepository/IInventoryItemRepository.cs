using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IInventoryItemRepository : IRepository<InventoryItem, long>
    {
        IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room);

        IEnumerable<InventoryItem> GetInventoryItems();
    }
}
