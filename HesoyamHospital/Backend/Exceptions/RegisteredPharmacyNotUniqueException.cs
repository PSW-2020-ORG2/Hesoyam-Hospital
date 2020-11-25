using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class RegisteredPharmacyNameNotUniqueException : Exception
    {
        public RegisteredPharmacyNameNotUniqueException()
        {

        }

        public RegisteredPharmacyNameNotUniqueException(string message) : base(message)
        {

        }

        public RegisteredPharmacyNameNotUniqueException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
