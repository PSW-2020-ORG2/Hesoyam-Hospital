// File:    RoomController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;
using SIMS.Util;

namespace SIMS.Controller.HospitalManagementController
{
    public class RoomController : IController<Room, long>
    {

        public RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        public IEnumerable<Room> GetRoomsByType(RoomType type)
            => roomService.GetRoomsByType(type);

        public IEnumerable<Room> GetAvailableRoomsByDate(TimeInterval timeInterval)
            => roomService.GetAvailableRoomsByDate(timeInterval);

        public void DivideRooms(Room initialRoom, string newNumbe)
            => roomService.DivideRooms(initialRoom, newNumbe);

        public Room MergeRooms(IEnumerable<Room> roomsToMerge, string newName)
            => roomService.MergeRooms(roomsToMerge, newName);

        public Room GetRoomByName(string name)
            => roomService.GetRoomByName(name);

        public IEnumerable<Room> GetRoomsByFloor(int floor)
            => roomService.GetRoomsByFloor(floor);

        public IEnumerable<Room> GetAll()
            => roomService.GetAll();

        public Room GetByID(long id)
            => roomService.GetByID(id);

        public Room Create(Room entity)
            => roomService.Create(entity);

        public void Update(Room entity)
            => roomService.Update(entity);

        public void Delete(Room entity)
            => roomService.Delete(entity);

    }
}