using Authentication.Model.Util;
using System;

namespace Authentication.Model.UserModel
{
    public class Person
    {
        public string Uidn { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Jmbg { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public virtual Address Address { get; set; }

        public Sex Sex { get; set; }

        public string FullName
        {
            get
            {
                if (MiddleName == null || MiddleName.Equals(""))
                    return Name + " " + Surname;
                else
                    return Name + " " + MiddleName + " " + Surname;
            }
        }

        public Person() { }
        public Person(string name,
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
                        string email2)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            Jmbg = jmbg;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            Uidn = uidn;
            Address = address;
            HomePhone = homePhone;
            CellPhone = cellPhone;
            Email1 = email1;
            Email2 = email2;
        }

        public Person(string name,
                        string surname,
                        string middleName,
                        string jmbg,
                        Sex sex,
                        DateTime dateOfBirth,
                        string uidn,
                        Address address,
                        string homePhone,
                        string cellPhone,
                        string email1)
        {
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            Jmbg = jmbg;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            Uidn = uidn;
            Address = address;
            HomePhone = homePhone;
            CellPhone = cellPhone;
            Email1 = email1;
        }
    }
}