using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException()
        {

        }

        public InvalidQuantityException(string message) : base(message)
        {

        }

        public InvalidQuantityException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
