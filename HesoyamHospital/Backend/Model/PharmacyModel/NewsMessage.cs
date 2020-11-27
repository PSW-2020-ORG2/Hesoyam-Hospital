using System;

namespace IntegrationAdapter.RabbitMQServiceSupport
{
    public class NewsMessage
    {
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public NewsMessage(string text, DateTime timestamp)
        {
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.Timestamp.ToString();
        }
    }
}
