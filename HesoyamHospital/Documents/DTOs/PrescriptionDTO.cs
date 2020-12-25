using System.Collections.Generic;

namespace Documents.DTOs
{
    public class PrescriptionDTO
    {
        public List<string> Medicine { get; set; }
        public string Status { get; set; }

        public PrescriptionDTO(List<string> med, string status) {
            Medicine = med;
            Status = status;
        }
    }
}
