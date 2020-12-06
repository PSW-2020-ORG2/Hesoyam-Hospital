using System;
using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class EquipmentAndMedicineRepository
    {
        public List<EquipmentAndMedicine> GetAllEquipmentAndMedicines(string fileName)
        {
            string path = Path.GetFullPath(fileName);
            List<EquipmentAndMedicine> list = new List<EquipmentAndMedicine>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    EquipmentAndMedicine equipmentAndMedicine = GetEquipmentAndMedicine(line);
                    list.Add(equipmentAndMedicine);
                }
            }
            else
            {
                return list;
            }
            return list;
        }

        private EquipmentAndMedicine GetEquipmentAndMedicine(string line)
        {
            string[] fields = line.Split(',');
            string type = fields[0].ToString();
            string name = fields[1].ToString();
            string mapObject = fields[2].ToString();
            string floor = fields[3].ToString();
            string room = fields[4].ToString();
            int quantity = Int32.Parse(fields[5]);

            return new EquipmentAndMedicine(type, name, mapObject, floor, room, quantity);

        }
    }
}
