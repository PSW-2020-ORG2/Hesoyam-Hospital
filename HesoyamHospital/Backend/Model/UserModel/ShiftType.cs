using Backend.Repository.Abstract;
using System;
namespace Backend.Model.UserModel
{
    public class ShiftType : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ShiftType(long id)
        {
            Id = id;
        }

        public ShiftType(long id, string name, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
