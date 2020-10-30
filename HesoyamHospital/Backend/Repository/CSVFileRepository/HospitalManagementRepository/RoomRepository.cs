// File:    RoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:38
// Purpose: Definition of Class RoomRepository

using Backend.Model.ManagerModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.HospitalManagementAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.CSVFileRepository.UsersRepository;
using Backend.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class RoomRepository : CSVRepository<Room, long>, IRoomRepository
    {
        private const string ENTITY_NAME = "Room";
        private const string NOT_UNIQUE_ERROR = "Room name {0} is not unique!";
        public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Room>())
        {
        }

        public new Room Create(Room room)
        {
            //Note (Gergo) : Ima smisla da naziv sobe bude jednoznacan
            if (IsRoomNumberUnique(room.RoomNumber))
            {
                return base.Create(room);
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, room.RoomNumber));
        }

        private bool IsRoomNumberUnique(string roomNumber)
            => GetRoomByName(roomNumber) == null;

        public Room GetRoomByName(string name)
            => GetAll().SingleOrDefault(room => room.RoomNumber == name);

        public IEnumerable<Room> GetRoomsByFloor(int floor)
            => GetAll().Where(room => room.Floor == floor);

        public IEnumerable<Room> GetRoomsByType(RoomType type)
            => GetAll().Where(room => room.RoomType == type);
    }
}