using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class UrgentMedicineProcurement
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; set; }
        public uint Quantity { get; set; }
        public bool Concluded { get; set; }
        public UrgentMedicineProcurement()
        {
            Concluded = false;
        }
        public UrgentMedicineProcurement(string medicine,uint quantity)
        {
            Medicine = medicine;
            Quantity = quantity;
            Concluded = false;
        }

        public void Conclude()
        {
            Concluded = true;
        }
    }
}
