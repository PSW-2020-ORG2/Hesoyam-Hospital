using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class SearchService
    {

        public SearchService()
        {
        }
       
        public List<MapLocation> FindObjectsByName(string name)
        {
            List<MapLocation> mapLocations = new List<MapLocation>();

            string[] fileEntries = Directory.GetFiles("Map_Files");
            foreach (string fileName in fileEntries)
            {
                if (fileName.ToLower().EndsWith(".txt"))
                {
                    List<MapLocation> mapLocation1 = ReadObjects(fileName, name);
                    mapLocations.AddRange(mapLocation1);
                }
            }

            return mapLocations;
        }

        public List<MapLocation> ReadObjects(string path, string name)
        {
            MapLocation location = null;
            List<MapLocation> locations = new List<MapLocation>();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> graphical_objects = graphic_repository.ReadFromFile(path);

            foreach (GraphicalObject obj in graphical_objects)
            {
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
