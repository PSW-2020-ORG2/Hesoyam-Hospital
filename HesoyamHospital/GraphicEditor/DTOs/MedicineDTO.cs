
namespace GraphicEditor
{
    class MedicineDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long Room { get; set; }
        public int Quantity { get; set; }

        public MedicineDTO()
        {

        }
        public MedicineDTO(string name, string type, long room, int quantity)
        {
            Name = name;
            Type = type;
            Room = room;
            Quantity = quantity;
        }
    }
}
