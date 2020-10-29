using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;

//CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class TimeTableRepository : CSVRepository<TimeTable, long>, ITimeTableRepository
    {
        private const string ENTITY_NAME = "TimeTable";
        public TimeTableRepository(ICSVStream<TimeTable> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<TimeTable>())
        {
        }

        
    }
}
