// File:    Person.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Person

using System;

namespace SIMS.Model.UserModel
{
    public class Person
    {
        private string _uidn;
        private string _name;
        private string _surname;
        private string _middleName;
        private DateTime _dateOfBirth;
        private string _homePhone;
        private string _cellPhone;
        private string _email1;
        private string _email2;

        private Address _address;
        private Sex _sex;

        public Person() { }
        public Person(  string name, 
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
        {
            _name = name;
            _surname = surname;
            _middleName = middleName;
            _sex = sex;
            _dateOfBirth = dateOfBirth;
            _uidn = uidn;
            _address = address;
            _homePhone = homePhone;
            _cellPhone = cellPhone;
            _email1 = email1;
            _email2 = email2;
        }


        public string FullName
        {
            get
            {
                if (_middleName.Equals(""))
                    return _name + " " + _surname;
                else
                    return _name + " " + _middleName + " " + _surname;
            }
        }

        public string Uidn { get => _uidn; set => _uidn = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string MiddleName { get => _middleName; set => _middleName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string HomePhone { get => _homePhone; set => _homePhone = value; }
        public string CellPhone { get => _cellPhone; set => _cellPhone = value; }
        public string Email1 { get => _email1; set => _email1 = value; }
        public string Email2 { get => _email2; set => _email2 = value; }
        public Address Address { get => _address; set => _address = value; }
        public Sex Sex { get => _sex; set => _sex = value; }
    }
}