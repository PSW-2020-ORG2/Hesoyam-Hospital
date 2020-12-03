using Backend.Model.UserModel;

namespace WebApplication.HospitalSurvey
{
    public static class SectionMapper
    {
        public static SectionDTO SectionToSectionDTO(Section section)
        {
            return new SectionDTO(section.AnswerOne,section.AnswerTwo,section.AnswerThree,
                section.AnswerFour);

        }
    }
}
