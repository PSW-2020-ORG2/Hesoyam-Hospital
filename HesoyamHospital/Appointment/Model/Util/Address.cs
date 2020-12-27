namespace Appointments.Model.Util
{
    public class Address
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public virtual Location Location { get; set; }

        public Address() { }
        public Address(string street, Location location)
        {
            Street = street;
            Location = location;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
        
        public override string ToString()
        {
            return Street + ", " +  Location.ToString();
        }
    }
}