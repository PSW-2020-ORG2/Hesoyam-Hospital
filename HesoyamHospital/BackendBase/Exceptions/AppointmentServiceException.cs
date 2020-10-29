using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class AppointmentServiceException : Exception
    {
        public AppointmentServiceException()
        {

        }

        public AppointmentServiceException(string message) : base(message)
        {

        }

        public AppointmentServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
