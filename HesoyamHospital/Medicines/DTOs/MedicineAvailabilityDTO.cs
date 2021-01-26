using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.DTOs
{
    public class MedicineAvailabilityDTO
    {
        public bool Available { get; set; }
        public List<string> Addresses { get; set; }
    }
}
