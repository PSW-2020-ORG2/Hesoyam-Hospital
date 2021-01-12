using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class TenderListing
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; set; }
        public uint Quantity { get; set; }
    }
}
