using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.UserModel;
using SIMS.Util;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    class TimeTableConverter : ICSVConverter<TimeTable>
    {
        private readonly string _delimiter = ">";
        private readonly string _listDelimiter = "~";
        private readonly string _secondListDelimiter = "_";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public TimeTableConverter()
        {
        }

        public TimeTable ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new TimeTable(
                    long.Parse(tokens[0]),
                    GetWorkTime(tokens[1])
                );
        }

        public string ConvertEntityToCSV(TimeTable entity)
            => string.Join(_delimiter,
                    entity.GetId(),
                    GetDictionaryCSV(entity.WorkingHours)
                );


        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
             => stringToSplit.Split(delimiter.ToCharArray());

        //        private long _id;
        //private Dictionary<WorkingDaysEnum, TimeInterval> _workingHours;
        private string GetDictionaryCSV(Dictionary<WorkingDaysEnum, TimeInterval> dict)
          => string.Join(_listDelimiter, dict.Select(workingDay => workingDay.Key + _secondListDelimiter + transformTimeIntervalToCSV(workingDay.Value)));


         private string transformTimeIntervalToCSV(TimeInterval timeInterval)
            => string.Join(_secondListDelimiter, timeInterval.StartTime.ToString(_dateTimeFormat), timeInterval.EndTime.ToString(_dateTimeFormat));

        private Dictionary<WorkingDaysEnum, TimeInterval> GetWorkTime(string workTimeCSV)
        {
            Dictionary<WorkingDaysEnum, TimeInterval> retVal = new Dictionary<WorkingDaysEnum, TimeInterval>();
            string[] perDayString = SplitStringByDelimiter(workTimeCSV, _listDelimiter);

            
            foreach (string dayLine in perDayString)
            {
                if (string.IsNullOrEmpty(dayLine)) continue; //It will skip invalid line. Known situation : entity was written to the file with an empty dict.
                string[] dayInfo = SplitStringByDelimiter(dayLine, _secondListDelimiter);
                WorkingDaysEnum day = (WorkingDaysEnum)Enum.Parse(typeof(WorkingDaysEnum), dayInfo[0]); //Casting 
                TimeInterval timeInterval = GetTimeInterval(dayInfo[1],dayInfo[2]);
                retVal.Add(day, timeInterval);
            }

            return retVal;
        }

        private DateTime GetDateTimeFromString(string dateTime)
            => DateTime.ParseExact(dateTime, _dateTimeFormat, null);

        private TimeInterval GetTimeInterval(string startDate, string endDate)
            => new TimeInterval(GetDateTimeFromString(startDate), GetDateTimeFromString(endDate));

    }
}
