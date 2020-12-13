using System;
using System.Collections.Generic;
using System.IO;

namespace GraphicEditor
{
    class EquipmentAndMedicineRepository
    {
        public List<EquipmentAndMedicineDTO> GetAllEquipmentAndMedicines(string fileName)
        {
            string path = Path.GetFullPath(fileName);
            List<EquipmentAndMedicineDTO> list = new List<EquipmentAndMedicineDTO>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    EquipmentAndMedicineDTO equipmentAndMedicine = GetEquipmentAndMedicine(line);
                    list.Add(equipmentAndMedicine);
                }
            }
            else
            {
                return list;
            }
            return list;
        }

        private EquipmentAndMedicineDTO GetEquipmentAndMedicine(string line)
        {
            string[] fields = line.Split(',');
            string type = fields[0].ToString();
            string name = fields[1].ToString();
            long room = Int32.Parse(fields[4]);
            int quantity = Int32.Parse(fields[5]);

            return new EquipmentAndMedicineDTO(type, name, room, quantity);

        }
    }
}
