using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    public class Section : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private long _answerOne;
        public long AnswerOne { get => _answerOne; set => _answerOne = value; }

        private long _answerTwo;
        public long AnswerTwo { get => _answerTwo; set => _answerTwo = value; }

        private long _answerThree;
        public long AnswerThree { get => _answerThree; set => _answerThree = value; }

        private long _answerFour;
        public long AnswerFour { get => _answerFour; set => _answerFour = value; }

        public Section()
        {
        }

        public Section(long id)
        {
            _id = id;
        }

        public Section(long id, long answerOne, long answerTwo, long answerThree, long answerFour)
        {
            _id = id;
            _answerOne = answerOne;
            _answerTwo = answerTwo;
            _answerThree = answerThree;
            _answerFour = answerFour;
        }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;
    }
}
