using Backend.Model.UserModel;
using Feedbacks.Repository.Abstract;
using Feedbacks.Repository.SQLRepository.Base;

namespace Feedbacks.Repository
{
    public class SurveyRepository : SQLRepository<Survey, long>, ISurveyRepository
    {
        public SurveyRepository(ISQLStream<Survey> stream) : base(stream)
        {
        }
    }
}
