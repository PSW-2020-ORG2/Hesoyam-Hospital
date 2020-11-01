// File:    Location.cs
// Author:  Geri
// Created: 19. april 2020 20:30:46
// Purpose: Definition of Class Location

using Backend.Repository.Abstract;
using System;

namespace Backend.Model.UserModel
{
    public class Location : IIdentifiable<long>
    {
        public long id { get; set; }

        private string _country;
        private string _city;

        public Location(string country, string city)
        {
            _country = country;
            _city = city;
        }

        public Location(long id, string country, string city)
        {
            id = id;
            _country = country;
            _city = city;
        }

        public Location(long id)
        {
            id = id;
        }

        public string Country
        {
            get { return _country;  }
            set { _country = value;  }
        }
        
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            id = id;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   id == location.id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + id.GetHashCode();
        }
    }
}