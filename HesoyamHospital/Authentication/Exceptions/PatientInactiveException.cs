using System;

namespace Authentication.Exceptions
{
    public class PatientInactiveException : Exception
    {
        public PatientInactiveException()
        {

        }

        public PatientInactiveException(string message) : base(message)
        {

        }

        public PatientInactiveException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
