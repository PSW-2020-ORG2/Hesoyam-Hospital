/***********************************************************************
 * Module:  Ingredients.cs
 * Author:  nikola
 * Purpose: Definition of the Class Ingredients
 ***********************************************************************/

using System;
using SIMS.Repository.Abstract;

namespace SIMS.Model.PatientModel
{
    public class Ingredient : IIdentifiable<long>
    {
        private string _name;
        private long _id;

        public Ingredient(long id)
        {
            _id = id;
        }

        public Ingredient(long id, string name)
        {
            _id = id;
            _name = name;
        }

        public Ingredient(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public long Id { get => _id; set => _id = value; }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Ingredient otherDisease = obj as Ingredient;
            return _id == otherDisease.GetId();
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}