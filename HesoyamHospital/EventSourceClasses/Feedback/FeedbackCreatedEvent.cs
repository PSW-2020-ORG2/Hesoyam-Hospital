using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EventSourceClasses.Feedback
{
    public class FeedbackCreatedEvent : Event
    {
        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("feedbackCreatedEventLoggerURL");
        public long Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Comment { get; set; }
        public bool Anonymous { get; set; }
        public bool Public { get; set; }
        public string Username { get; set; }

        public FeedbackCreatedEvent() { }

        public FeedbackCreatedEvent(string comment, bool anonymous, bool isPublic, string username){
            Comment = comment;
            Anonymous = anonymous;
            Public = isPublic;
            Username = username;
        }

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }catch(JsonSerializationException e)
            {
                Console.WriteLine("Serilization error occured during feedback created logging.");
            }
        }
    }
}
