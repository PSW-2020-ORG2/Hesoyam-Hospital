using SIMS.Model.ManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    class InventoryItemConverter : ICSVConverter<InventoryItem>
    {
        //private string _name;
        //private int _inStock;
        //private int _minNumber;
        //private long _id;
        //private Room _room;
        private readonly string _delimiter = ">";

        public InventoryItemConverter()
        {
        }
        public InventoryItem ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new InventoryItem(
                    long.Parse(tokens[0]),
                    tokens[1],
                    int.Parse(tokens[2]),
                    int.Parse(tokens[3]),
                    GetDummyRoom(tokens[4])
                );
        }
  
        public string ConvertEntityToCSV(InventoryItem entity)
            => string.Join(_delimiter, entity.GetId(), entity.Name, entity.InStock, entity.MinNumber, entity.Room.GetId());

        private Room GetDummyRoom(string id)
            => new Room(long.Parse(id));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
          => stringToSplit.Split(delimiter.ToCharArray());
    }
}
