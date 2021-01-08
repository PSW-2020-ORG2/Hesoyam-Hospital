using Backend.Repository.Abstract;
using System.Text.Json.Serialization;

namespace Backend.Model.PharmacyModel
{
    public class TenderOfferListing : IIdentifiable<long>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; set; }
        public uint Quantity { get; set; }
        public decimal UnitPrice { get; set; }

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