using ActionsAndBenefits.Repository.Abstract;
using System;
using System.Text.Json.Serialization;

namespace ActionsAndBenefits.Model
{
    public class ActionBenefit
    {
        //[JsonIgnore]
        public long Id { get; set; }
        public string Text { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool Approved { get; private set; }

        public ActionBenefit(string text, DateTime timestamp)
        {
            if (string.IsNullOrWhiteSpace(text) || timestamp == null)
                throw new ArgumentNullException();
            Text = text;
            Timestamp = timestamp;
            Approved = false;
        }

        public override string ToString()
        {
            return Text + " sent at " + Timestamp.ToString();
        }
        public void ChangeText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
                throw new ArgumentNullException();
            Text = newText;
        }
        public void ChangeTimestamp(DateTime newTimestamp)
        {
            Timestamp = newTimestamp;
        }
        public void Approve()
        {
            Approved = true;
        }
    }
}
