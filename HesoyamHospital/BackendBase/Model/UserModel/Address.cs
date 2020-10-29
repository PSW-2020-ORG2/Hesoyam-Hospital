// File:    Address.cs
// Author:  Geri
// Created: 22. maj 2020 12:12:12
// Purpose: Definition of Class Address

using System;

namespace SIMS.Model.UserModel
{
    public class Address
    {
        private string _address; //street
        private Location _location;

        public Address(string address, Location location)
        {
            _address = address;
            _location = location;
        }

        public string Street
        {
            get { return _address; }
            set { _address = value;  }
        }
        
        public Location Location
        {
            get { return _location;  }
            set { _location = value;  }
        }
    }
}