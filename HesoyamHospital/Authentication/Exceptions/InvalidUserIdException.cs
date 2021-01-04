using System;

namespace Authentication.Exceptions
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException()
        {

        }

        public InvalidUserIdException(string message) : base(message)
        {

        }

        public InvalidUserIdException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
