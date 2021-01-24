using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class TenderOffer
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long TenderId { get; set; }
        public string PharmacyName { get; set; }
        public string Email { get; set; }
        public virtual List<TenderOfferListing> TenderOfferListings { get; set; }
        public TenderOffer()
        {
        }
        public TenderOffer(long tenderId,string email,List<TenderOfferListing>list)
        {
            TenderId = tenderId;
            Email = email;
            TenderOfferListings = list;
        }
    }
}
