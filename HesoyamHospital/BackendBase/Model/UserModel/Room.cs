/***********************************************************************
 * Module:  Room.cs
 * Author:  vule
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using System.Collections.Generic;
using SIMS.Model.ManagerModel;
using SIMS.Repository.Abstract;

namespace SIMS.Model.UserModel
{
    public class Room: IIdentifiable<long>
    {
        private long _id;
        private string _roomNumber;
        private bool _occupied;
        private int _floor;
        private RoomType _roomType;

        public Room(long id)
        {
            _id = id;
        }
        

        public Room(string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            _roomNumber = roomNumber;
            _occupied = occupied;
            _floor = floor;
            _roomType = roomType;
        }

        public Room(long id, string roomNumber, bool occupied, int floor, RoomType roomType)
        {
            _id = id;
            _roomNumber = roomNumber;
            _occupied = occupied;
            _floor = floor;
            _roomType = roomType;
        }

        public string RoomNumber { get => _roomNumber; set => _roomNumber = value; }
        public bool Occupied { get => _occupied; set => _occupied = value; }
        public int Floor { get => _floor; set => _floor = value; }
        public RoomType RoomType { get => _roomType; set => _roomType = value; }

        public override bool Equals(object obj)
        {
            var room = obj as Room;
            return room != null &&
                   _id == room._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }
    }
}