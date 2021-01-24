using System;

namespace MedicineProcurement.Exceptions
{
    public class NullDateException : Exception
    {
        public NullDateException()
        {

        }

        public NullDateException(string message) : base(message)
        {

        }

        public NullDateException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
