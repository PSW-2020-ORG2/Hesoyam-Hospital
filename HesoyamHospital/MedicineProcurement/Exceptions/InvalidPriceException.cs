using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException()
        {

        }

        public InvalidPriceException(string message) : base(message)
        {

        }

        public InvalidPriceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
