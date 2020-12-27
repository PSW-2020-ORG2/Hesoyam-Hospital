using System;

namespace Appointments.Exceptions
{
    class InvalidUserIdException : Exception
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
