using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Model
{
    public class ApiKey
    {
        public string KeyID { get; set; }

        public ApiKey(string keyid)
        {
            KeyID = keyid;
        }
        public ApiKey() { }
    }
}
