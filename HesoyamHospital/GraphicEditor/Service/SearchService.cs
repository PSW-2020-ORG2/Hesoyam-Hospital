using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class SearchService
    {
        public SearchService()
        {
        }
        public List<EquipmentAndMedicine> FindAllEquipmentAndMedicines(string filename)
        {
            List<EquipmentAndMedicine> allEquipment = null;
            EquipmentAndMedicineRepository equipmentAndMedicineRepository = new EquipmentAndMedicineRepository();
            allEquipment = equipmentAndMedicineRepository.GetAllEquipmentAndMedicines(filename);
            return allEquipment;
        }
        public List<EquipmentAndMedicine> GetEquipmentAndMedicineByName(string filename, string name)
        {
            List<EquipmentAndMedicine> allEquipment = null;
            List<EquipmentAndMedicine> findEquipmentAndMedicine = new List<EquipmentAndMedicine>();
            EquipmentAndMedicineRepository equipmentAndMedicineRepository = new EquipmentAndMedicineRepository();

            allEquipment = equipmentAndMedicineRepository.GetAllEquipmentAndMedicines(filename);

            foreach (EquipmentAndMedicine e in allEquipment)
            {
                if (e.Name.Equals(name))
                {
                    findEquipmentAndMedicine.Add(e);
                }
            }

            return findEquipmentAndMedicine;
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
