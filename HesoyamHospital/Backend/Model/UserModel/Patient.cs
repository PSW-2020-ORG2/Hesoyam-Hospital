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
        private PatientType _patientType;
        public PatientType PatientType { get => _patientType; set => _patientType = value; }

        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor { get => _selectedDoctor; set { _selectedDoctor = value; _selectedDoctorID = value.Id; } }

        private long _selectedDoctorID;
        public long SelectedDoctorID { get => _selectedDoctorID; set => _selectedDoctorID = value; }

        private bool _active;
        public bool Active { get => _active; set => _active = value; }

        private string _healthCardNumber;
        public string HealthCardNumber { get => _healthCardNumber; set => _healthCardNumber = value; }

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
                        PatientType patientType, 
                        Doctor selectedDoctor,
                        string healthCardNumber) 
            : base(userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _selectedDoctorID = selectedDoctor.Id;
            _healthCardNumber = healthCardNumber;
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
                        PatientType patientType,
                        Doctor selectedDoctor,
                        string healthCardNumber)
            : base(userName, password, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _selectedDoctorID = selectedDoctor.Id;
            _healthCardNumber = healthCardNumber;
        }
        //constructor for NewPatientMapper
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
            _healthCardNumber = healthCardNumber;
            _active = false;
            _selectedDoctorID = 500;
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
                        PatientType patientType, 
                        Doctor selectedDoctor,
                        string healthCardNumber) 
            : base(id, uid, userName, password, dateCreated, name, surname, middleName, jmbg, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _selectedDoctorID = selectedDoctor.Id;
            _healthCardNumber = healthCardNumber;
        }
    }
}