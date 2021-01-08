using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException()
        {

        }

        public InvalidEmailFormatException(string message) : base(message)
        {

        }

        public InvalidEmailFormatException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
