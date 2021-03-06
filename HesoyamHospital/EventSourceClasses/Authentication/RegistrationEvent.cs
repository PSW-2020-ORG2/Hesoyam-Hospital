﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace EventSourceClasses.Authentication
{
    public class RegistrationEvent : Event

    {
        private readonly string LOG_END_POINT = Environment.GetEnvironmentVariable("createdRegistrationEventLoggerURL");

        public long Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HealthCardNumber { get; set; }
        public string Jmbg { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string BloodType { get; set; }
        public List<string> Allergies { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }



        public RegistrationEvent() { }

        public RegistrationEvent(string name, string surname, string middlename, string gender, string email, string username, string password, DateTime dateofbirth, string healthcardnumber, string jmbg, string mobilephone, string homephone, string bloodtype, List<String> allergies, string country, string city, string address)
        {
            Name = name;
            Surname = surname;
            MiddleName = middlename;
            Gender = gender;
            Email = email;
            Username = username;
            Password = password;
            DateOfBirth = dateofbirth;
            HealthCardNumber = healthcardnumber;
            Jmbg = jmbg;
            MobilePhone = mobilephone;
            HomePhone = homephone;
            BloodType = bloodtype;
            Allergies = allergies;
            Country = country;
            City = city;
            Address = address;
        }

        public RegistrationEvent(string name, string surname, string middlename, string gender, string email, string username, string password, DateTime dateofbirth, string healthcardnumber, string jmbg, string mobilephone, string homephone, string bloodtype, List<String> allergies, string country, string city, string address, DateTime timestamp)
        {
            Name = name;
            Surname = surname;
            MiddleName = middlename;
            Gender = gender;
            Email = email;
            Username = username;
            Password = password;
            DateOfBirth = dateofbirth;
            HealthCardNumber = healthcardnumber;
            Jmbg = jmbg;
            MobilePhone = mobilephone;
            HomePhone = homephone;
            BloodType = bloodtype;
            Allergies = allergies;
            Country = country;
            City = city;
            Address = address;
            Timestamp = timestamp;
        }

        public override void Log()
        {
            try
            {
                LogObject(LOG_END_POINT);
            }
            catch (JsonSerializationException e)
            {
                Console.WriteLine("Serilization error occured during login attempt.");
            }
        }
    }
}
