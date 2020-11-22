/***********************************************************************
 * Module:  Allergy.cs
 * Author:  nikola
 * Purpose: Definition of the Class Allergy
 ***********************************************************************/

using System;
using Backend.Repository.Abstract;
using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class Allergy : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }

        private string _name;
        public string Name { get => _name; set => _name = value; }

        public Allergy(long id)
        {
            _id = id;
            _name = "";
            
        }

        public Allergy(long id,string name)
        {
            _id = id;
            _name = name;
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var allergy = obj as Allergy;
            return allergy != null &&
                   _id == allergy._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}