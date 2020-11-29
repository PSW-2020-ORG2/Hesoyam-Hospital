using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor
{
    public class MapLocation
    {
        
        public string Name { get; set; }

        public string Hospital { get; set; }

        public string Floor { get; set; }

        public MapLocation() 
        { 
        }

        public MapLocation(string hospital, string floor, string name)
        {
            Name = name;
            Hospital = hospital;
            Floor = floor;

        }

        
 
    }
}
