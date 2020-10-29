using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class DoctorStatisticsConverter : ICSVConverter<StatsDoctor>
    {
        private readonly string _delimiter = ",";
        
        public DoctorStatisticsConverter(string delimiter) 
        {
            _delimiter = delimiter;

        }
        public StatsDoctor ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            return new StatsDoctor(
                long.Parse(tokens[0]),
                Double.Parse(tokens[1]),
                tokens[2],
                GetDummyDoctor(tokens[3])
                );
        }

        private Doctor GetDummyDoctor(string v)
            => new Doctor(new UserID(v));

        public string ConvertEntityToCSV(StatsDoctor entity)
            => string.Join(_delimiter,
                entity.GetId().ToString(),
                entity.NumberOfAppointments.ToString(),
                entity.AvgAppointmentTime,
                entity.Doctor.GetId().ToString()
                );
    }
}
