using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Exceptions
{
    public class TherapyServiceException : Exception
    {
        public TherapyServiceException()
        {

        }

        public TherapyServiceException(string message) : base(message)
        {

        }

        public TherapyServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
