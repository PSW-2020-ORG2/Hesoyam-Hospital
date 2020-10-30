// File:    Rating.cs
// Author:  Geri
// Created: 18. april 2020 20:35:26
// Purpose: Definition of Class Rating

using Backend.Repository.Abstract;
using System;

namespace Backend.Model.UserModel
{
    public class Rating
    {
        private int _stars;
        private string _comment;

        public int Stars { get { return _stars; } set { _stars = value; }}

        public string Comment { get => _comment; set => _comment = value; }

        public Rating(string comment, int stars)
        {
            _comment = comment;
            _stars = stars;
        }

        public Rating() { }
    }
}