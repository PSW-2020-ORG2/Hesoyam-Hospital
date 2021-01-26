using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineProcurement.DTOs
{
    public class RegisteredPharmacyDTO
    {
        public string PharmacyName { get; set; }
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string GrpcPort { get; set; }
        public string ExtractDomainName()
        {
            string[] parts = Endpoint.Split('/');
            string domainName = parts[2].Split(':')[0];
            return domainName;
        }
    }
}
