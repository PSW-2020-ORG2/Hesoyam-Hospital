
namespace GraphicEditor.DTOs
{
    class EquipmentDTO
    {
        public string Name { get; set; }
        public long Room { get; set; }
        public int Quantity { get; set; }

        public EquipmentDTO(string name, long room, int quantity)
        {
            Name = name;
            Room = room;
            Quantity = quantity;
        }
    }
}
