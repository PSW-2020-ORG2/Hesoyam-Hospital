using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.HospitalSurvey
{
    public class SurveyDTO
    {
        public long DoctorId { get; set; }
        public int AnswerOne { get; set; }
        public int AnswerTwo { get; set; }
        public int AnswerThree { get; set; }
        public int AnswerFour { get; set; }
        public int AnswerFive { get; set; }
        public int AnswerSix { get; set; }
        public int AnswerSeven { get; set; }
        public int AnswerEight { get; set; }
        public int AnswerNine { get; set; }
        public int AnswerTen { get; set; }
        public int AnswerEleven { get; set; }
        public int AnswerTwelve { get; set; }
        public int AnswerThirteen { get; set; }
        public int AnswerFourteen { get; set; }
        public int AnswerFifteen { get; set; }
        public int AnswerSixteen { get; set; }
        public int AnswerSeventeen { get; set; }
        public int AnswerEighteen { get; set; }

        public SurveyDTO(long doctorId, int answerOne, int answerTwo, int answerThree, int answerFour, 
            int answerFive, int answerSix, int answerSeven, int answerEight, int answerNine, int answerTen, 
            int answerEleven, int answerTwelve, int answerThirteen, int answerFourteen, int answerFifteen,
            int answerSixteen, int answerSeventeen, int answerEighteen)
        {
            DoctorId = doctorId;
            AnswerOne = answerOne;
            AnswerTwo = answerTwo;
            AnswerThree = answerThree;
            AnswerFour = answerFour;
            AnswerFive = answerFive;
            AnswerSix = answerSix;
            AnswerSeven = answerSeven;
            AnswerEight = answerEight;
            AnswerNine = answerNine;
            AnswerTen = answerTen;
            AnswerEleven = answerEleven;
            AnswerTwelve = answerTwelve;
            AnswerThirteen = answerThirteen;
            AnswerFourteen = answerFourteen;
            AnswerFifteen = answerFifteen;
            AnswerSixteen = answerSixteen;
            AnswerSeventeen = answerSeventeen;
            AnswerEighteen = answerEighteen;


        }

        SurveyDTO()
        {

        }
    }
}
