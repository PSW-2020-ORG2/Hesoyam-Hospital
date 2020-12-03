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
            List<MapLocation> mapLocations = new List<MapLocation>();
            List<MapLocation> mapLocation1 = Find_in_file("hospital1groundfloor.txt", name);
            List<MapLocation> mapLocation2 = Find_in_file("hospital1firstfloor.txt", name);
            List<MapLocation> mapLocation3 = Find_in_file("hospital2groundfloor.txt", name);
            List<MapLocation> mapLocation4 = Find_in_file("hospital2firstfloor.txt", name);
            List<MapLocation> mapLocation5 = Find_in_file("hospital2secondfloor.txt", name);

            mapLocations.AddRange(mapLocation1);
            
            mapLocations.AddRange(mapLocation2);

            mapLocations.AddRange(mapLocation3);
            
            mapLocations.AddRange(mapLocation4);
            
            mapLocations.AddRange(mapLocation5);

            return mapLocations;
        }

        public List<MapLocation> Find_in_file(string path, string name)
        {
            List<String> names = new List<string>();
            MapLocation location = null ;
            List<MapLocation> locations = new List<MapLocation>();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> graphical_objects = graphic_repository.ReadFromFile(path);

            foreach (GraphicalObject obj in graphical_objects) {
                if (obj.Name.Contains(name)) 
                {
                    string full_name = obj.Name;
                    location = Get_Location_By_Filename(path, full_name);
                    locations.Add(location);
                    
                }
            }

            return locations;
        
        }

        public MapLocation Get_Location_By_Filename(string path, string name) {
            MapLocation location = new MapLocation();

            location.Name = name;
            if (path.Contains("1"))
            {
                location.Hospital = "Hospital 1";
            }
            if (path.Contains("2"))
            {
                location.Hospital = "Hospital 2";
            }
            if (path.Contains("first"))
            {
                location.Floor = "First Floor";
            }
            if (path.Contains("second"))
            {
                location.Floor = "Second Floor";
            }
            if (path.Contains("ground"))
            {
                location.Floor = "Ground Floor";
            }

            return location;
        }

    }
}
