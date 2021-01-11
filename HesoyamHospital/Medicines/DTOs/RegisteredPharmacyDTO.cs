using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.DTOs
{
    public class RegisteredPharmacyDTO
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string GrpcPort { get; set; }
    }
}
