using System;
using System.Collections.Generic;

namespace GraphicEditor
{
    class SearchService
    {
        public SearchService()
        {
        }

        public List<MapLocation> Find_objects_by_name(string name) 
        {
            List<MapLocation> map_locations = new List<MapLocation>();
            List<MapLocation> map_location1 = Find_in_file("hospital1groundfloor.txt", name);
            List<MapLocation> map_location2 = Find_in_file("hospital1firstfloor.txt", name);
            List<MapLocation> map_location3 = Find_in_file("hospital2groundfloor.txt", name);
            List<MapLocation> map_location4 = Find_in_file("hospital2firstfloor.txt", name);
            List<MapLocation> map_location5 = Find_in_file("hospital2secondfloor.txt", name);

            map_locations.AddRange(map_location1);
            
            map_locations.AddRange(map_location2);

            map_locations.AddRange(map_location3);
            
            map_locations.AddRange(map_location4);
            
            map_locations.AddRange(map_location5);

            return map_locations;
        }

        public List<MapLocation> Find_in_file(string path, string name)
        {
            MapLocation map_location = null ;
            List<MapLocation> map_locations = new List<MapLocation>();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> graphical_objects = graphic_repository.ReadFromFile(path);

            foreach (GraphicalObject obj in graphical_objects) {
                if (obj.Name.Contains(name)) 
                {
                    string full_name = obj.Name;
                    map_location = Get_Location_By_Filename(path, full_name);
                    map_locations.Add(map_location);
                    
                }
            }

            return map_locations;
        
        }

        public MapLocation Get_Location_By_Filename(string path, string name) {
            MapLocation map_location = new MapLocation();

            map_location.Name = name;
            if (path.Contains("1"))
            {
                map_location.Hospital = "Hospital 1";
            }
            if (path.Contains("2"))
            {
                map_location.Hospital = "Hospital 2";
            }
            if (path.Contains("first"))
            { 
                map_location.Floor = "First Floor";
            }
            if (path.Contains("second"))
            {
                map_location.Floor = "Second Floor";
            }
            if (path.Contains("ground"))
            {
                map_location.Floor = "Ground Floor";
            }

            return map_location;
        }

    }
}
