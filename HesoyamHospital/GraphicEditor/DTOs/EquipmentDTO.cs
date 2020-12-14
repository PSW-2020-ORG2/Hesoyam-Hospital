
namespace GraphicEditor.DTOs
{
    class EquipmentDTO
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public int Quantity { get; set; }

        public EquipmentDTO(string name, string room, int quantity)
        {
            Name = name;
            Room = room;
            Quantity = quantity;
        }

    }
}
