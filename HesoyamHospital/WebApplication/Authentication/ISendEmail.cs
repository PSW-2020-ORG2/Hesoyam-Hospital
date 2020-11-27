using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Authentication
{
    public interface ISendEmail
    {
        public void SendActivationEmail(long id);
    }
}
