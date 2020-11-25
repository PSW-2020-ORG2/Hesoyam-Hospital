using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
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
        //returns list of mean values per questions in doctors section
        public List<double> MeanValuesPerDoctorQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section doctorSection = survey.DoctorSection;
                answersOne.Add(doctorSection.AnswerOne);
                answersTwo.Add(doctorSection.AnswerTwo);
                answersThree.Add(doctorSection.AnswerThree);
                answersFour.Add(doctorSection.AnswerFour);
            }
            result.Add(SumOfQuestions(answersOne) / surveys.Count);
            result.Add(SumOfQuestions(answersTwo) / surveys.Count);
            result.Add(SumOfQuestions(answersThree) / surveys.Count);
            result.Add(SumOfQuestions(answersFour) / surveys.Count);

            return result;

        }
        public List<double> MeanValuesPerStaffQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section staffSection = survey.StaffSection;
                answersOne.Add(staffSection.AnswerOne);
                answersTwo.Add(staffSection.AnswerTwo);
                answersThree.Add(staffSection.AnswerThree);
                answersFour.Add(staffSection.AnswerFour);
            }
            result.Add(SumOfQuestions(answersOne) / surveys.Count);
            result.Add(SumOfQuestions(answersTwo) / surveys.Count);
            result.Add(SumOfQuestions(answersThree) / surveys.Count);
            result.Add(SumOfQuestions(answersFour) / surveys.Count);

            return result;

        }
        public List<double> MeanValuesPerHygieneQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section hygieneSection = survey.HygieneSection;
                answersOne.Add(hygieneSection.AnswerOne);
                answersTwo.Add(hygieneSection.AnswerTwo);
                answersThree.Add(hygieneSection.AnswerThree);
                answersFour.Add(hygieneSection.AnswerFour);
            }
            result.Add(SumOfQuestions(answersOne) / surveys.Count);
            result.Add(SumOfQuestions(answersTwo) / surveys.Count);
            result.Add(SumOfQuestions(answersThree) / surveys.Count);
            result.Add(SumOfQuestions(answersFour) / surveys.Count);

            return result;

        }

        public List<double> MeanValuesPerEquipmentQuestions()
        {
            List<double> result = new List<double>();
            List<double> answersOne = new List<double>();
            List<double> answersTwo = new List<double>();
            List<double> answersThree = new List<double>();
            List<double> answersFour = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return result;
            }
            foreach (Survey survey in surveys)
            {
                Section equipmentSection = survey.EquipmentSection;
                answersOne.Add(equipmentSection.AnswerOne);
                answersTwo.Add(equipmentSection.AnswerTwo);
                answersThree.Add(equipmentSection.AnswerThree);
                answersFour.Add(equipmentSection.AnswerFour);
            }
            result.Add(SumOfQuestions(answersOne) / surveys.Count);
            result.Add(SumOfQuestions(answersTwo) / surveys.Count);
            result.Add(SumOfQuestions(answersThree) / surveys.Count);
            result.Add(SumOfQuestions(answersFour) / surveys.Count);

            return result;

        }
        public double SumOfQuestions(List<double> means) 
        {
            double result=0.0;
            foreach( double question in means)
            {
                result += question;
            }
            return result;
        }
        public double MeanValuesPerDoctorSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section doctorSection = survey.DoctorSection;
                means.Add(SumOfAnswers(doctorSection));
              
            }
            return SumPerSections(means)/surveys.Count();
        }

        public double MeanValuesPerStaffSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section staffSection = survey.StaffSection;
                means.Add(SumOfAnswers(staffSection));

            }
            return SumPerSections(means) / surveys.Count();
        }
        public double MeanValuesPerEquipmentSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section equipmentSection = survey.EquipmentSection;
                means.Add(SumOfAnswers(equipmentSection));

            }
            return SumPerSections(means) / surveys.Count();
        }
        public double MeanValuesPerHygieneSection()
        {
            List<double> means = new List<double>();
            List<Survey> surveys = _surveyRepository.GetAllEager().ToList();

            if (surveys == null)
            {
                return 0.0;
            }
            foreach (Survey survey in surveys)
            {
                Section hygieneSection = survey.HygieneSection;
                means.Add(SumOfAnswers(hygieneSection));

            }
            return SumPerSections(means) / surveys.Count();
        }

        public double SumOfAnswers(Section section)
        {
            return (section.AnswerOne + section.AnswerTwo + section.AnswerThree + section.AnswerFour )/4;
        }
        public double SumPerSections(List<double> sums)
        {
            double result = 0.0;    
            
            foreach (double sum in sums)
            {
                result += sum;

            }
            return result;
        }
    }
}
