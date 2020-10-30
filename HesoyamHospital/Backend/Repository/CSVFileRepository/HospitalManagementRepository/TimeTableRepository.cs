using System;
using System.Collections.Generic;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;

//CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>

namespace Backend.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class TimeTableRepository : CSVRepository<TimeTable, long>, ITimeTableRepository
    {
        private const string ENTITY_NAME = "TimeTable";
        public TimeTableRepository(ICSVStream<TimeTable> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<TimeTable>())
        {
        }

        
    }
}
