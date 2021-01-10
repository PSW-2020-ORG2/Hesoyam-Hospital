using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Model.PharmacyModel
{
    public class Tender : IIdentifiable<long>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public virtual List<TenderListing> TenderListings { get; set; }
        public DateTime EndDate { get; set; }
        public Tender()
        {
        }
        public Tender(List<TenderListing>listing,DateTime endDate)
        {
            TenderListings = listing;
            EndDate = endDate;
        }
        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
        public bool IsActive()
        {
            return (DateTime.Now < EndDate);
        }
    }
}
