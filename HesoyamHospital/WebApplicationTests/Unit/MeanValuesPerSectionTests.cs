using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Service.UsersService;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.HospitalSurvey;
using Xunit;

namespace WebApplicationTests.Unit
{
    public class MeanValuesPerSectionTests
    {
        [Fact]
        public void Shows_Sum_Per_Section()
        {
            //SurveyService service = new SurveyService(ISurveyRepository());
        }
        private static ISurveyRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();
            var surveys = new List<Survey>();
            SurveyDTO surveydto = new SurveyDTO (1, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 2, 8);
            Survey survey = SurveyMapper.SurveyDTOToSurvey(surveydto);
            surveys.Add(survey);
            stubRepository.Setup(m => m.GetAll()).Returns(surveys);
            return stubRepository.Object;
                
         }
    }
}
