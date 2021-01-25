using PharmacyRegistration.DTOs;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyRegistration.Model
{
    public class RegisteredPharmacy
    {
        [JsonIgnore]
        public long Id { get; set; }
        [Required]
        public virtual ApiKey ApiKey { get; private set; }
        [Required]
        public string PharmacyName { get; private set; }
        [Required]
        public virtual Endpoint Endpoint { get; private set; }
        public string GrpcPort { get; private set; }
        public RegisteredPharmacy(ApiKey apiKey, string pharmacyName, Endpoint endpoint, string grpcPort)
        {
            if (string.IsNullOrWhiteSpace(apiKey.KeyID) || string.IsNullOrWhiteSpace(pharmacyName) || string.IsNullOrWhiteSpace(endpoint.EndpointURL))
                throw new ArgumentNullException();
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
            GrpcPort = grpcPort;
        }
        public RegisteredPharmacy(RegisterPharmacyDTO dto)
        {
            ApiKey = new ApiKey(dto.ApiKey);
            Endpoint = new Endpoint(dto.Endpoint);
            PharmacyName = dto.PharmacyName;
            GrpcPort = dto.GrpcPort;
        }
        public RegisteredPharmacy() { }
        public void ChangeApiKey(ApiKey newApiKey)
        {
            ValidateStringField(newApiKey.KeyID);
            ApiKey = newApiKey;
        }
        public void ChangePharmacyName(string newPharmacyName)
        {
            ValidateStringField(newPharmacyName);
            PharmacyName = newPharmacyName;
        }
        public void ChangeEndpoint(Endpoint newEndpoint)
        {
            ValidateStringField(newEndpoint.EndpointURL);
            Endpoint = newEndpoint;
        }
        public void ChangeGrpcPort(string newGrpcPort)
        {
            ValidateStringField(newGrpcPort);
            GrpcPort = newGrpcPort;
        }

        private static void ValidateStringField(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName) || string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException();
        }
    }
}
