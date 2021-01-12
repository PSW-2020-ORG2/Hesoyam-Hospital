using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedicineProcurement.Model
{
    public class Tender
    {
        [JsonIgnore]
        public long Id { get; set; }
        public virtual List<TenderListing> TenderListings { get; set; }
        public DateTime EndDate { get; set; }
        public bool Concluded { get; private set; }
        public long TenderOfferWinnerId { get; set; }
        public Tender()
        {
            Concluded = false;
        }
        public Tender(List<TenderListing>listing, DateTime endDate)
        {
            TenderListings = listing;
            EndDate = endDate;
        }
        public bool IsActive()
        {
            return (DateTime.Now < EndDate);
        }
        public void Conclude(long tenderOfferWinnderId)
        {
            Concluded = true;
            TenderOfferWinnerId = tenderOfferWinnderId;
        }
    }
}
