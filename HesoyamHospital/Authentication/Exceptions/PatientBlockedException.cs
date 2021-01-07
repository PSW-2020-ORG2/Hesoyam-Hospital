using System;

namespace Authentication.Exceptions
{
    public class PatientBlockedException : Exception
    {
        public PatientBlockedException()
        {

        }

        public PatientBlockedException(string message) : base(message)
        {

        }

        public PatientBlockedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
