using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.DTOs
{
    public class InventoryNameDTO
    {
        public string Name { get; set; }

        public InventoryNameDTO(string name)
        {
            Name = name;
        }
    }
}
