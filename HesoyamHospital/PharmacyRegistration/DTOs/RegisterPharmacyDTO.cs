using PharmacyRegistration.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PharmacyRegistration.DTOs
{
    public class RegisterPharmacyDTO
    {
        [Required]
        public string ApiKey { get; set; }
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string Endpoint { get; set; }
        public string GrpcPort { get; set; }
        public RegisterPharmacyDTO(string apiKey, string pharmacyName, string endpoint)
        {
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
        }
        public RegisterPharmacyDTO() { }

        public RegisterPharmacyDTO(RegisteredPharmacy pharmacy)
        {
            ApiKey = pharmacy.ApiKey.KeyID;
            PharmacyName = pharmacy.PharmacyName;
            Endpoint = pharmacy.Endpoint.EndpointURL;
            GrpcPort = GrpcPort;
        }
    }
}
