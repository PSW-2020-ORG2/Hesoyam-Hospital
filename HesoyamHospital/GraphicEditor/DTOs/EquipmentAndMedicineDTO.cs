
namespace GraphicEditor
{
    class EquipmentAndMedicineDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public long Room { get; set; }
        public int Quantity { get; set; }


        public EquipmentAndMedicineDTO(string type, string name, long room, int quantity)
        {
            Type = type;
            Name = name;
            Room = room;
            Quantity = quantity;
        }
    }
}
