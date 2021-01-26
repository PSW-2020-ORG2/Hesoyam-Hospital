using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyRegistration.Model
{
    public class Endpoint
    {
        public string EndpointURL { get; set; }

        public Endpoint(string endpointURL)
        {
            EndpointURL = endpointURL;
        }
        public string ExtractDomainName()
        {
            string[] parts = EndpointURL.Split('/');
            string domainName = parts[2].Split(':')[0];
            return domainName;
        }
        public Endpoint() { }
    }
}
