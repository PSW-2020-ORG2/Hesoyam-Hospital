using Authentication.Model.FeedbackModel;
using Authentication.Model.UserModel;
using System.Collections.Generic;

namespace Feedbacks.Service.Abstract
{
    public interface ISurveyService : IService<Survey, long>
    {
        public List<Section> GetAnswersPerDoctorSections();
        public List<Section> GetAnswersPerStaffSections();
        public List<Section> GetAnswersPerHygieneSections();
        public List<Section> GetAnswersPerEquipmentSections();
        public double GetAvarageGradePerDoctors(Doctor doctor);
        public List<Section> GetSurveysPerDoctors(Doctor doctor);
        public Dictionary<string, List<long>> FrequencyPerDoctorQuestions();
        public Dictionary<string, List<long>> FrequencyPerStaffQuestions();
        public Dictionary<string, List<long>> FrequencyPerHygieneQuestions();
        public Dictionary<string, List<long>> FrequencyPerEquipmentQuestions();
        public List<long> CalculateFrequency(List<long> answers);
        public List<double> MeanValuesPerDoctorQuestions();
        public List<double> MeanValuesPerStaffQuestions();
        public List<double> MeanValuesPerHygieneQuestions();
        public List<double> MeanValuesPerEquipmentQuestions();
        public double SumOfQuestions(List<double> means);
        public double MeanValuesPerDoctorSection();
        public double MeanValuesPerStaffSection();
        public double MeanValuesPerEquipmentSection();
        public double MeanValuesPerHygieneSection();
        public double SumOfAnswers(Section section);
        public double SumPerSections(List<double> sums);
    }
}
