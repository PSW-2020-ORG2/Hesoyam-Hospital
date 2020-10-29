using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class NotificationServiceException : Exception
    {
        public NotificationServiceException()
        {

        }

        public NotificationServiceException(string message) : base(message)
        {

        }

        public NotificationServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
