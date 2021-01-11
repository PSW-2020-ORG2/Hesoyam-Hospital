using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Model.Authentication
{
    public class BlockPatientEvent
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }

        public BlockPatientEvent() { }
        public BlockPatientEvent(string username)
        {
            Username = username;
        }
        public BlockPatientEvent(string username, DateTime timestamp)
        {
            Username = username;
            Timestamp = timestamp;
        }
    }
}
