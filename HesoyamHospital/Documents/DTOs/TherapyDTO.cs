namespace Documents.DTOs
{
    public class TherapyDTO
    {
        public string MedicineName { get; set; }
        public string TherapyTime { get; set; }
        public double Quantity { get; set; }

        public TherapyDTO() { }

        public TherapyDTO(string medicineName, string therapyTime, double quantity)
        {
            MedicineName = medicineName;
            TherapyTime = therapyTime;
            Quantity = quantity;
        }
    }
}
