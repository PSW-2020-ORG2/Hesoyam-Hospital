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
                    location = new MapLocation(obj.Hospital, obj.Floor, obj.Name, path);

                    locations.Add(location);
                    
                }
            }

            return locations;
        
        }

    }
}
