using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class QuestionRepository : CSVRepository<Question, long>, IQuestionRepository
    {
        private const string ENTITY_NAME = "Question";
        public QuestionRepository(ICSVStream<Question> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Question>())
        {
        }
    }
}
