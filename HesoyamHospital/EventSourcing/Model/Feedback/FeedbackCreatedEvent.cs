using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Model.Feedback
{
    public class FeedbackCreatedEvent
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public long Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Comment { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public string Username { get; set; }

        public FeedbackCreatedEvent() { }

        public FeedbackCreatedEvent(string comment, bool anonymous, bool isPublic, string username)
        {
            Comment = comment;
            Anonymous = anonymous;
            Public = isPublic;
            Username = username;
        }
    }
}
