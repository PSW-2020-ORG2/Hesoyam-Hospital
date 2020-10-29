using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    class RoomStatisticsConverter : ICSVConverter<StatsRoom>
    {
        private readonly string _delimiter = ",";

        public RoomStatisticsConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public StatsRoom ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            return new StatsRoom(
                long.Parse(tokens[0]),
                double.Parse(tokens[1]),
                double.Parse(tokens[2]),
                int.Parse(tokens[3]),
                new Room(long.Parse(tokens[4]))
                );
        }

        public string ConvertEntityToCSV(StatsRoom entity)
            => string.Join(_delimiter,
                entity.GetId().ToString(),
                entity.Usage.ToString(),
                entity.TimeOccupied.ToString(),
                entity.AvgAppointmentTime.ToString(),
                entity.Room.GetId().ToString()
                );
    }
}
