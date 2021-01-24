using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class TenderOfferListing
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; set; }
        public uint Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public TenderOfferListing(string medicine,uint quantity,decimal unitPrice)
        {
            Medicine = medicine;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}