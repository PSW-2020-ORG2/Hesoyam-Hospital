using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyRegistration.Model
{
    public class RegisteredPharmacy
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required]
        public string ApiKey { get; set; }
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string Endpoint { get; set; }
        public string GrpcPort { get; set; }
        public RegisteredPharmacy(string apiKey, string pharmacyName, string endpoint)
        {
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
        }
        public RegisteredPharmacy() { }
    }
}
