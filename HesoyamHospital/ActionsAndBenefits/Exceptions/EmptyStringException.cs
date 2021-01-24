﻿using System;

namespace ActionsAndBenefits.Exceptions
{
    public class EmptyStringException : Exception
    {
        public EmptyStringException()
        {

        }

        public EmptyStringException(string message) : base(message)
        {

        }

        public EmptyStringException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
