namespace Authentication.Model.UserModel
{
    public class Room
    {
        public long Id { get; set; }
        public string RoomNumber { get; set; }
        public bool Occupied { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }

        public Room(long id)
        {
            Id = id;
        }

        public Room(string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            RoomNumber = roomNumber;
            Occupied = occupied;
            Floor = floor;
            RoomType = roomType;
        }

        public Room(long id, string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            Id = id;
            RoomNumber = roomNumber;
            Occupied = occupied;
            Floor = floor;
            RoomType = roomType;
        }

        public override bool Equals(object obj)
        {
            return obj is Room room && Id == room.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}