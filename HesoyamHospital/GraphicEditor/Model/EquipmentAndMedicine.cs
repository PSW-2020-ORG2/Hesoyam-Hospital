using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor
{
    class EquipmentAndMedicine
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public string MapObject { get; set; }

        public string Floor { get; set; }

        public string Room { get; set; }

        public int Quantity { get; set; }


        public EquipmentAndMedicine(string type, string name, string mapObject, string floor, string room, int quantity)
        {
            Type = type;
            Name = name;
            MapObject = mapObject;
            Floor = floor;
            Room = room;
            Quantity = quantity;
        }
    }
}
