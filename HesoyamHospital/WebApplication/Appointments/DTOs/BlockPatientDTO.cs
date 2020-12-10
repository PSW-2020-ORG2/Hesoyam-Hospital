using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Appointments.DTOs
{
    public class BlockPatientDTO
    {
        public string Username { get; set; }
        public int CancelCount { get; set; }
        public string FullName { get; set; }
        public bool Blocked { get; set; }

        public BlockPatientDTO(string username, int cancelCount, string fullName, bool blocked)
        {
            Username = username;
            CancelCount = cancelCount;
            FullName = fullName;
            Blocked = blocked;
        }
    }
}
