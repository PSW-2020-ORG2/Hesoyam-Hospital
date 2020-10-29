/***********************************************************************
 * Module:  Patient.cs
 * Author:  nikola
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;

namespace SIMS.Model.UserModel
{
    public class Patient : User
    {
        private PatientType _patientType;
        //public MedicalRecord medicalRecord;
        private EmergencyContact _emergencyContact;

        private Doctor _selectedDoctor;

        public Patient(UserID id) : base(id) { }

        public Patient( string userName, 
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
                        EmergencyContact emergencyContact, 
                        PatientType patientType, 
                        Doctor selectedDoctor) 
            : base(userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
        }

        public Patient(string userName,
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
                        EmergencyContact emergencyContact,
                        PatientType patientType,
                        Doctor selectedDoctor)
            : base(userName, password, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
        }

        public Patient( UserID id, 
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
                        EmergencyContact emergencyContact, 
                        PatientType patientType, 
                        Doctor selectedDoctor) 
            : base(id, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
        }

        public PatientType PatientType { get => _patientType; }
        public EmergencyContact EmergencyContact { get => _emergencyContact; }
        public Doctor SelectedDoctor { get => _selectedDoctor; set => _selectedDoctor = value; }
    }
}