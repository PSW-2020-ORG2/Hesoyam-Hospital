using System;

namespace Authentication.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException()
        {

        }

        public InvalidRoleException(string message) : base(message)
        {

        }

        public InvalidRoleException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
