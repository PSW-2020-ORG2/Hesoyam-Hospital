using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.UsersService
{
    public class SurveyService : IService<Survey, long>
    {
        private SurveyRepository _surveyRepository;

        public SurveyService(SurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
            
        }
        public Survey Create(Survey entity)
        {
            Validate(entity);

            return _surveyRepository.Create(entity);
        }

        public void Delete(Survey entity)
            => _surveyRepository.Delete(entity);

        public IEnumerable<Survey> GetAll()
            => _surveyRepository.GetAllEager();

        public Survey GetByID(long id)
            => _surveyRepository.GetEager(id);

        public void Update(Survey entity)
        {
            Validate(entity);
            _surveyRepository.Update(entity);
        }

        public void Validate(Survey entity)
        {
            
        }
    }
}
