// File:    Address.cs
// Author:  Geri
// Created: 22. maj 2020 12:12:12
// Purpose: Definition of Class Address

using System;
using System.Diagnostics.Eventing.Reader;

namespace Backend.Model.UserModel
{
    public class Address
    {
        private string _address; //street
        private Location _location;
        public long Id { get; set; }
        public Address() { }
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
        
        public virtual Location Location
        {
            get { return _location;  }
            set { _location = value;  }
        }
    }
}