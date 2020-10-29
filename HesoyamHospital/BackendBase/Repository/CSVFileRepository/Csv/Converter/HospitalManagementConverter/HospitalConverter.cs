// File:    HospitalConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:52:53
// Purpose: Definition of Class HospitalConverter

using System;
using SIMS.Model.UserModel;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class HospitalConverter : ICSVConverter<Hospital>
    {
        private readonly string _delimiter = "|";
        private readonly string _listDelimiter = "~"; //Delimiter used for separating room IDs.

        public HospitalConverter()
        {
        }

        public Hospital ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            Address dummyAddress = GetDummyAddress(SplitStringByDelimiter(tokens[2], _listDelimiter));
            List<Room> dummyRooms = (tokens[5] == "" ? new List<Room>() : GetDummyRooms(SplitStringByDelimiter(tokens[5], _listDelimiter))); 
            List<Employee> dummyEmployees = (tokens[6] == "" ? new List<Employee>() : GetDummyEmployee(SplitStringByDelimiter(tokens[6], _listDelimiter)));

            return new Hospital(
                long.Parse(tokens[0]),
                tokens[1],
                dummyAddress, 
                tokens[3], 
                tokens[4], 
                dummyRooms, 
                dummyEmployees
                );
        }

        public string ConvertEntityToCSV(Hospital entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Name,
                GetAddressCSVstring(entity.Address),
                entity.Telephone,
                entity.Website,
                GetRoomIDSCSVstring(entity.Room),
                GetEmployeeIDSCSVstring(entity.Employee));

        private string GetAddressCSVstring(Address address)
           => string.Join(_listDelimiter, address.Street, address.Location.GetId(), address.Location.Country, address.Location.City);

        private string GetRoomIDSCSVstring(IEnumerable<Room> roomList)
            => string.Join(_listDelimiter, roomList.Select(room => room.GetId()));

        private string GetEmployeeIDSCSVstring(IEnumerable<Employee> employeeList)
            => string.Join(_listDelimiter, employeeList.Select(employee => employee.GetId()));
        
        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private List<Room> GetDummyRooms(string[] ids)
            => ids.ToList().ConvertAll(x => new Room(long.Parse(x)));

        private List<Employee> GetDummyEmployee(string[] ids)
            => ids.ToList().ConvertAll(x => new Employee(new UserID(x)));

        private Address GetDummyAddress(string[] data)
            => new Address(data[0], new Location(long.Parse(data[1]), data[2], data[3]));

    }
}