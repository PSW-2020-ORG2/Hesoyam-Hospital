// File:    Employee.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Employee

using System;

namespace SIMS.Model.UserModel
{
    public class Employee : User
    {
        private TimeTable _timeTable;
        private Hospital _hospital;

        public Employee(UserID id) : base(id) { }

        public Employee(TimeTable timeTable, 
                        Hospital hospital, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2) 
            : base(userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _hospital = hospital;
        }

        public Employee(TimeTable timeTable,
                        Hospital hospital,
                        string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2)
            : base(userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _hospital = hospital;
        }

        public Employee(UserID id, 
                        TimeTable timeTable, 
                        Hospital hospital, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2) 
            : base(id, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _timeTable = timeTable;
            _hospital = hospital;
        }

        public Hospital Hospital
        {
            get
            {
                return _hospital;
            }
            set
            {
                if (_hospital == null || !_hospital.Equals(value))
                {
                    if (_hospital != null)
                    {
                        Hospital oldHospital = _hospital;
                        _hospital = null;
                        oldHospital.RemoveEmployee(this);
                    }
                    if (value != null)
                    {
                        _hospital = value;
                        _hospital.AddEmployee(this);
                    }
                }
            }
        }

        public TimeTable TimeTable { get => _timeTable; set => _timeTable = value; }
    }
}