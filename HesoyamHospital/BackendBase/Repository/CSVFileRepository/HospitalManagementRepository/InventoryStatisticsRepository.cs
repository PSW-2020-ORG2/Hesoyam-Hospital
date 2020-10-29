using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class InventoryStatisticsRepository : CSVRepository<StatsInventory, long>, IInventoryStatisticsRepository, IEagerCSVRepository<StatsInventory, long>
    {
        private IMedicineRepository _medicineRepository;
        private IInventoryItemRepository _inventoryItemRepository;
        private const string ENTITY_NAME = "Inventory Statistics Repository";
        public InventoryStatisticsRepository(ICSVStream<StatsInventory> stream, ISequencer<long> sequencer, IMedicineRepository medicineRepository, IInventoryItemRepository inventoryItemRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<StatsInventory>())
        {
            _inventoryItemRepository = inventoryItemRepository;
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<StatsInventory> GetAllEager()
        {
            IEnumerable<StatsInventory> allStats = GetAll();
            IEnumerable<InventoryItem> items = _inventoryItemRepository.GetAll();
            IEnumerable<Medicine> allMedicine = _medicineRepository.GetAll();

            Bind(allStats, items, allMedicine);

            return allStats;
        }

        private void Bind(IEnumerable<StatsInventory> allStats, IEnumerable<InventoryItem> items, IEnumerable<Medicine> allMedicine)
        {
            BindStatsWithMedicine(allStats, allMedicine);
            BindStatsWithItems(allStats, items);
        }

        private void BindStatsWithItems(IEnumerable<StatsInventory> allStats, IEnumerable<InventoryItem> items)
            => allStats.ToList().ForEach(stat => stat.InventoryItem = GetItemById(items, stat.InventoryItem.GetId()));

        private InventoryItem GetItemById(IEnumerable<InventoryItem> items, long v)
            => items.SingleOrDefault(item => item.GetId() == v);

        private void BindStatsWithMedicine(IEnumerable<StatsInventory> allStats, IEnumerable<Medicine> allMedicine)
        => allStats.ToList().ForEach(stat => stat.Medicine = GetMedicineById(allMedicine, stat.Medicine.GetId()));

        private Medicine GetMedicineById(IEnumerable<Medicine> allMedicine, long v)
        => allMedicine.SingleOrDefault(med => med.GetId() == v);

        public StatsInventory GetEager(long id)
            => GetAllEager().SingleOrDefault(stat => stat.GetId() == id);

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
