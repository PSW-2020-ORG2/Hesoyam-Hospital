using ActionsAndBenefits.Repository.Abstract;
using System;
using System.Text.Json.Serialization;

namespace ActionsAndBenefits.Model
{
    public class ActionBenefit
    {
        //[JsonIgnore]
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Approved { get; set; }

        public ActionBenefit()
        {
            Approved = false;
        }

        public ActionBenefit(string text, DateTime timestamp)
        {
            Text = text;
            Timestamp = timestamp;
            Approved = false;
        }

        public override string ToString()
        {
            return Text + " sent at " + Timestamp.ToString();
        }
        public void Approve()
        {
            Approved = true;
        }
    }
}
