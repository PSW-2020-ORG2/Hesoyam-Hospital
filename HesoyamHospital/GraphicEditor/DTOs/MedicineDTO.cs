
namespace GraphicEditor
{
    class MedicineDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Room { get; set; }
        public int Quantity { get; set; }

        public MedicineDTO()
        {

        }
        public MedicineDTO(string name, string type, string room, int quantity)
        {
            Name = name;
            Type = type;
            Room = room;
            Quantity = quantity;
        }
    }
}
