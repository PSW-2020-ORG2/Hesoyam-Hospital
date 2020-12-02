using Backend.Repository.Abstract;
using System;
using System.Text.Json.Serialization;

namespace Backend.Model.PharmacyModel
{
    public class ActionBenefit : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        [JsonIgnore]
        public bool Approved { get; set; }

        public ActionBenefit() { }

        public ActionBenefit(string text, DateTime timestamp)
        {
            this.Text = text;
            this.Timestamp = timestamp;
            this.Approved = false;
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.Timestamp.ToString();
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
