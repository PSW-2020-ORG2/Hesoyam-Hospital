using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Exceptions
{
    public class BadAppointmentException : Exception
    {
        public BadAppointmentException() : base() { }
        public BadAppointmentException(string message) : base(message) { }
    }
}
