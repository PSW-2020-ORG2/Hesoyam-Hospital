using Controller;
using SIMS.Model.ManagerModel;
using SIMS.Service.HospitalManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller.HospitalManagementController
{
    class InventoryStatisticsController : IController<StatsInventory, long>
    {
        InventoryStatisticsService _inventoryStatisticsService;

        public InventoryStatisticsController(InventoryStatisticsService inventoryStatisticsService)
        {
            _inventoryStatisticsService = inventoryStatisticsService;
        }

        public StatsInventory Create(StatsInventory entity)
            => _inventoryStatisticsService.Create(entity);

        public void Delete(StatsInventory entity)
            => _inventoryStatisticsService.Delete(entity);

        public IEnumerable<StatsInventory> GetAll()
            => _inventoryStatisticsService.GetAll();

        public StatsInventory GetByID(long id)
            => _inventoryStatisticsService.GetByID(id);

        public void Update(StatsInventory entity)
            => _inventoryStatisticsService.Update(entity);
    }
}
