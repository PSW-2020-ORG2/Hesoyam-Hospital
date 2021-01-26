using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.DTOs
{
    public class MedicineDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public MedicineDTO()
        {
        }
        public MedicineDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
