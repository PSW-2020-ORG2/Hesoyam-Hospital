using System;

namespace MedicineProcurement.Exceptions
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
