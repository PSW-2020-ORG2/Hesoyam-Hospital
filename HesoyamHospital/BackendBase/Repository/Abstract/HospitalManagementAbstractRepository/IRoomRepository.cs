// File:    IRoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:58:05
// Purpose: Definition of Interface IRoomRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IRoomRepository : IRepository<Room, long>
    {
        IEnumerable<Room> GetRoomsByType(RoomType type);

        Room GetRoomByName(string name);

        IEnumerable<Room> GetRoomsByFloor(int floor);

    }
}