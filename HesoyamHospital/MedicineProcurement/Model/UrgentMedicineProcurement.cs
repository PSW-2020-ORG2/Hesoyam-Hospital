using System;
using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class UrgentMedicineProcurement
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; private set; }
        public uint Quantity { get; private set; }
        public bool Concluded { get; private set; }

        public UrgentMedicineProcurement(string medicine, uint quantity)
        {
            if (string.IsNullOrWhiteSpace(medicine) || quantity < 1)
                throw new ArgumentNullException();
            Medicine = medicine;
            Quantity = quantity;
            Concluded = false;
        }
        public void ChangeMedicine(string newMedicine)
        {
            if (string.IsNullOrWhiteSpace(newMedicine))
                throw new ArgumentNullException();
            Medicine = newMedicine;
        }
        public void ChangeQuantity(uint newQuantity)
        {
            if (newQuantity < 1)
                throw new ArgumentNullException();
            Quantity = newQuantity;
        }
        public void Conclude()
        {
            Concluded = true;
        }
    }
}
