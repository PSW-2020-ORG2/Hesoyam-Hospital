using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Model.PharmacyModel
{
    public class TenderListing : IIdentifiable<long>
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Medicine { get; set; }
        public uint Quantity { get; set; }

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
