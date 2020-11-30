using System;

namespace Backend.Exceptions
{
    public class NullDateException : Exception
    {
        public NullDateException()
        {

        }

        public NullDateException(string message) : base(message)
        {

        }

        public NullDateException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
