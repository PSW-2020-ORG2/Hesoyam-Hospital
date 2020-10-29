// File:    Secretary.cs
// Author:  Geri
// Created: 18. april 2020 19:47:23
// Purpose: Definition of Class Secretary

using System;

namespace SIMS.Model.UserModel
{
    public class Secretary : Employee
    {
        public Secretary(UserID id) : base(id) { }

        public Secretary(   string userName,
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
                            string email2, 
                            TimeTable timeTable, 
                            Hospital hospital) 
            : base(timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Secretary(string userName,
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
                            string email2,
                            TimeTable timeTable,
                            Hospital hospital)
            : base(timeTable, hospital, userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Secretary(   UserID id,
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
                            string email2, 
                            TimeTable timeTable, 
                            Hospital hospital) 
            : base(id, timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }
    }
}