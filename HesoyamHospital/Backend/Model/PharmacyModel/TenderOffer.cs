using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Model.PharmacyModel
{
    public class TenderOffer : IIdentifiable<long>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long TenderId { get; set; }
        public string Email { get; set; }
        public virtual List<TenderOfferListing> TenderOfferListings { get; set; }
        public TenderOffer()
        {
        }
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
