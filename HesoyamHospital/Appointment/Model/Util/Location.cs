namespace Appointments.Model.Util
{
    public class Location
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public Location(string country, string city)
        {
            Country = country;
            City = city;
        }

        public Location(long id, string country, string city)
        {
            Id = id;
            Country = country;
            City = city;
        }

        public Location(long id)
        {
            Id = id;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            return obj is Location location && Id == location.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return City + ", " + Country;
        }
    }
}