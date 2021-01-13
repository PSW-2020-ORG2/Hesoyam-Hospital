using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class TenderStillActiveException : Exception
    {
        public TenderStillActiveException()
        {

        }
        public TenderStillActiveException(string message) : base(message)
        {

        }

        public TenderStillActiveException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
