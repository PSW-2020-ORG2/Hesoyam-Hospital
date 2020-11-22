using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.MySQLRepository.MySQL;
using Backend.Repository.MySQLRepository.MySQL.IdGenerator;
using Backend.Repository.MySQLRepository.MySQL.Stream;
using Backend.Repository.Sequencer;
using Backend.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.MySQLRepository.UsersRepository
{
    public class SurveyRepository : MySQLRepository<Survey, long>, ISurveyRepository, IEagerRepository<Survey, long>
    {
        private const string ENTITY_NAME = "";
        private string[] INCLUDE_PROPERTIES = { "" };
        public SurveyRepository(IMySQLStream<Survey> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Survey>())
        {
        }
        public IEnumerable<Survey> GetAllEager()
           => GetAllEager(INCLUDE_PROPERTIES);

        public Survey GetEager(long id)
            => GetAllEager().SingleOrDefault(survey => survey.GetId() == id);


    }
}
