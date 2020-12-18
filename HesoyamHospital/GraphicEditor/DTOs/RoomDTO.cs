using System;
using System.Collections.Generic;
using System.Text;
using Backend.Model.UserModel;

namespace GraphicEditor.DTOs
{
    class RoomDTO
    {
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public int Floor { get; set; }

        public RoomDTO()
        {

        }
        public RoomDTO(string name, RoomType type, int floor)
        {
            Name = name;
            Type = type;
            Floor = floor;

        }
    }
}
