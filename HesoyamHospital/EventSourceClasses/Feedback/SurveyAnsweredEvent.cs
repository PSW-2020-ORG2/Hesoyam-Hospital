﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace EventSourceClasses.Feedback
{
    public class SurveyAnsweredEvent : Event
    {

        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("surveyAnsweredEventLoggerURL");
        public long Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;


        public long AnswerOne { get; set; }
        public long AnswerTwo { get; set; }
        public long AnswerThree { get; set; }
        public long AnswerFour { get; set; }
        public long AnswerFive { get; set; }
        public long AnswerSix { get; set; }
        public long AnswerSeven { get; set; }
        public long AnswerEight { get; set; }
        public long AnswerNine { get; set; }
        public long AnswerTen { get; set; }
        public long AnswerEleven { get; set; }
        public long AnswerTwelve { get; set; }
        public long AnswerThirteen { get; set; }
        public long AnswerFourteen { get; set; }
        public long AnswerFifteen { get; set; }
        public long AnswerSixteen { get; set; }

        public long AppointmentId { get; set; }

        SurveyAnsweredEvent()
        {
        }

        public SurveyAnsweredEvent(long appointmentId, long answerOne, long answerTwo, long answerThree, long answerFour,
            long answerFive, long answerSix, long answerSeven, long answerEight, long answerNine, long answerTen,
            long answerEleven, long answerTwelve, long answerThirteen, long answerFourteen, long answerFifteen,
            long answerSixteen)
        {
            AppointmentId = appointmentId;
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
        }

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }catch(JsonSerializationException e)
            {
                Console.WriteLine("Serialization error occured during logging survey answered event.");
            }
        }
    }
}
