using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class InventoryStatisticsConverter : ICSVConverter<StatsInventory>
    {
        private readonly string _delimiter = ",";

        public InventoryStatisticsConverter(string delimiter)
        {
            _delimiter = delimiter;

        }
        public StatsInventory ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            return new StatsInventory(
                long.Parse(tokens[0]),
                double.Parse(tokens[1]),
                GetDummyMedicine(tokens[2]),
                GetDummyItem(tokens[3])
                );
        }

        private InventoryItem GetDummyItem(string v)
            => new InventoryItem(long.Parse(v));

        private Medicine GetDummyMedicine(string v)
            => new Medicine(long.Parse(v));

        public string ConvertEntityToCSV(StatsInventory entity)
            => string.Join(_delimiter,
                entity.GetId().ToString(),
                entity.Usage.ToString(),
                entity.Medicine.GetId().ToString(),
                entity.InventoryItem.GetId().ToString()
                );
    }
}
