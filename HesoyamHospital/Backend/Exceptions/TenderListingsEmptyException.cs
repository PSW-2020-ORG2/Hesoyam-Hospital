using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class TenderListingsEmptyException : Exception
    {
        public TenderListingsEmptyException()
        {

        }

        public TenderListingsEmptyException(string message) : base(message)
        {

        }

        public TenderListingsEmptyException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
