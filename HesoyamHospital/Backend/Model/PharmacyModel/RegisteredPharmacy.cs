using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.PharmacyModel
{
    public class RegisteredPharmacy : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string ApiKey { get; set; }
        [Key]
        public string PharmacyName { get; set; }
        public string Endpoint { get; set; }
        public RegisteredPharmacy(string apiKey, string pharmacyName, string endpoint)
        {
            ApiKey = apiKey;
            PharmacyName = pharmacyName;
            Endpoint = endpoint;
        }
        public RegisteredPharmacy() { }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
