﻿using System.Collections.Generic;
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
            List<MapLocation> locations = new List<MapLocation>();
            GraphicRepository graphic_repository = new GraphicRepository();
            List<GraphicalObject> graphical_objects = graphic_repository.ReadFromFile(path);

            foreach (GraphicalObject obj in graphical_objects)
            {
                if (obj.Name.Contains(name))
                {
                    MapLocation location = new MapLocation(obj.Hospital, obj.Floor, obj.Name, path);

                    locations.Add(location);

                }
            }

            return locations;

        }
        public void DisplayResults(MapLocation mapLocation)
        {
            Global.SearchObjectName = mapLocation.Name;
            string hospital = mapLocation.Hospital;
            string path = mapLocation.FilePath;
            string floor = mapLocation.Floor;
            string comboBoxPath = "";

            GraphicRepository graphicRepository = new GraphicRepository();
            List<FileInformation> menuInformation = graphicRepository.readFileInformation("Map_Files\\buildings.txt");

            foreach (FileInformation inf in menuInformation)
                if (inf.Name == hospital)
                    comboBoxPath = inf.FilePath;

            HospitalWindow window = new HospitalWindow(hospital, comboBoxPath);
            window.Hospital.Content = new HospitalFloor(path);
            window.HospitalFloors.Text = floor;
            window.Show();
        }

        public MapLocation GetLocationByRoomName(string room)
        {
            List<MapLocation> mapLocations = FindObjectsByName(room);
            return mapLocations[0];
        }
    }
}
