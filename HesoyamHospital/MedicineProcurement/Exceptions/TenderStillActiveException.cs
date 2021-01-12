using System;

namespace MedicineProcurement.Exceptions
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
