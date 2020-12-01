/***********************************************************************
 * Module:  Manager.cs
 * Author:  vule
 * Purpose: Definition of the Class Manager
 ***********************************************************************/

using System;

namespace Backend.Model.UserModel
{
    public class Manager : Employee
    {
        public Manager(long id) : base(id) { }

        public Manager( string userName,
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        Hospital hospital) 
            : base(hospital, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Manager(string userName,
                        string password,
                        string name,
                        string surname,
                        string middleName,
                        string jmbg,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1,
                        string email2,
                        Hospital hospital)
            : base(hospital, userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }

        public Manager( long id,
                        UserID uid, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        string jmbg,
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        Hospital hospital) 
            : base(id, uid, hospital, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {

        }
    }
}