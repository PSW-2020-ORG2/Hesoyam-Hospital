using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IInventoryStatisticsRepository
    {
        StatsInventory GetInventoryStatistics();

        StatsInventory GetStatisticsByItem(Item item);
    }
}
