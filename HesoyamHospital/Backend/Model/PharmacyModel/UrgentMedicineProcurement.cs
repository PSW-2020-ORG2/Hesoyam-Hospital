using Backend.Model.PatientModel;
using Backend.Repository.Abstract;
using System.Text.Json.Serialization;

namespace Backend.Model.PharmacyModel
{
    public class UrgentMedicineProcurement : IIdentifiable<long>
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
