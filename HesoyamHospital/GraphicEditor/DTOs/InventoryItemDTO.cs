
namespace GraphicEditor.DTOs
{
    class InventoryItemDTO
    {
        public string Name { get; set; }
        public string Room { get; set; }
        public int Quantity { get; set; }

        public InventoryItemDTO(string name, string room, int quantity)
        {
            Name = name;
            Room = room;
            Quantity = quantity;
        }

    }
}
