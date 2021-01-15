using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Backend.Model.ManagerModel;
using Backend.Model.UserModel;

namespace Backend.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IInventoryItemRepository : IRepository<InventoryItem, long>
    {
        IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room);

        IEnumerable<InventoryItem> GetInventoryItems();

        IEnumerable<InventoryItem> GetInventoryItemsByName(string name);

        IEnumerable<InventoryItem> GetInventoryItemsByRoomId(long id);

        InventoryItem GetInventoryItemById(long id);
    }
}
