// File:    Location.cs
// Author:  Geri
// Created: 19. april 2020 20:30:46
// Purpose: Definition of Class Location

using SIMS.Repository.Abstract;
using System;

namespace SIMS.Model.UserModel
{
    public class Location : IIdentifiable<long>
    {
        private long _id;

        private string _country;
        private string _city;

        public Location(string country, string city)
        {
            _country = country;
            _city = city;
        }

        public Location(long id, string country, string city)
        {
            _id = id;
            _country = country;
            _city = city;
        }

        public Location(long id)
        {
            _id = id;
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
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   _id == location._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}