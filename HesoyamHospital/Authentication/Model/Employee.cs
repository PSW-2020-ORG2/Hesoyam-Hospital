using Authentication.Util;
using System;

namespace Authentication.Model
{
    public class Employee : User
    {
        private Hospital _hospital;
        public virtual Hospital Hospital
        {
            get { return _hospital; }
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

        public Employee() : base() { }
        public Employee(long id) : base(id) { }

        public Employee(Hospital hospital, 
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
                        string email2) 
            : base(userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Hospital = hospital;
        }

        public Employee(Hospital hospital,
                        string userName,
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
                        string email2)
            : base(userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Hospital = hospital;
        }

        public Employee(long id,
                        UserID uid, 
                        Hospital hospital, 
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
                        string email2) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            Hospital = hospital;
        }
    }
}