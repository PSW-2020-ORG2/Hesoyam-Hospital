using Authentication.Model.FeedbackModel;
using Feedbacks.DTOs;

namespace Feedbacks.Mappers
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
