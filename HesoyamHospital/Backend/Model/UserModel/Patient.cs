/***********************************************************************
 * Module:  Patient.cs
 * Author:  nikola
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;

namespace Backend.Model.UserModel
{
    public class Patient : User
    {
        public virtual Doctor SelectedDoctor { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public string HealthCardNumber { get; set; }
        public virtual List<Appointment> Appointments { get; set; }

        public Patient(long id) : base(id) { }
        
        public Patient( string userName, 
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
                        Doctor selectedDoctor,
                        string healthCardNumber) 
            : base(userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            SelectedDoctor = selectedDoctor;
            HealthCardNumber = healthCardNumber;
        }

        public Patient(string userName,
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
                        Doctor selectedDoctor,
                        string healthCardNumber)
            : base(userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            SelectedDoctor = selectedDoctor;
            HealthCardNumber = healthCardNumber;
        }

        public Patient(string userName,
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
                        string healthCardNumber)
            : base(userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1)
        {
            HealthCardNumber = healthCardNumber;
            Active = false;
        }

        public Patient( long id,
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
                        Doctor selectedDoctor,
                        string healthCardNumber) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            SelectedDoctor = selectedDoctor;
            HealthCardNumber = healthCardNumber;
        }
    }
}