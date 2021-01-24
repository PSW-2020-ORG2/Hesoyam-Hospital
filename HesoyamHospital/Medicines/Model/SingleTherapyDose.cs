namespace Medicines.Model
{
    public class SingleTherapyDose
    {
        public long Id { get; set; }
        public TherapyTime TherapyTime { get; set; }
        public double Quantity { get; set; }

        public SingleTherapyDose()
        {

        }

        public SingleTherapyDose(TherapyTime therapyTime, double quantity)
        {
            TherapyTime = therapyTime;
            Quantity = quantity;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            return obj is SingleTherapyDose dose && Id == dose.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}
