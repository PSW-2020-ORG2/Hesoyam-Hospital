/***********************************************************************
 * Module:  Allergy.cs
 * Author:  nikola
 * Purpose: Definition of the Class Allergy
 ***********************************************************************/

using System;
using SIMS.Repository.Abstract;
using System.Collections.Generic;

namespace SIMS.Model.PatientModel
{
    public class Allergy : IIdentifiable<long>
    {
        private string _name;
        private long _id;

        private Ingredient _allergicToIngredient;
        private List<Symptom> _symptoms;

        public Allergy(long id)
        {
            _id = id;
            _name = "";
            _symptoms = new List<Symptom>();
            _allergicToIngredient = null; 
        }

        public Allergy(long id,string name, Ingredient allergicToIngredient, List<Symptom> symptomList = null)
        {
            _id = id;
            _name = name;
            _allergicToIngredient = allergicToIngredient;
            if (symptomList == null)
                _symptoms = new List<Symptom>();
            else
                _symptoms = symptomList;
        }

        public Allergy(string name,Ingredient allergicToIngredient,List<Symptom> symptomList = null)
        {
            _name = name;
            _allergicToIngredient = allergicToIngredient;
            if (symptomList == null)
                _symptoms = new List<Symptom>();
            else
                _symptoms = symptomList;
        }

        public Allergy(string name, Ingredient allergicToIngredient)
        {
            _name = name;
            _allergicToIngredient = allergicToIngredient;
            _symptoms = new List<Symptom>();
        }


        public Ingredient AllergicToIngredient
        {
            get { return _allergicToIngredient; }
            set { _allergicToIngredient = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Property for collection of Symptom
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Symptom> Symptoms
        {
            get
            {
                if (_symptoms == null)
                    _symptoms = new List<Symptom>();
                return _symptoms;
            }
            set
            {
                RemoveAllSymptoms();
                if (value != null)
                {
                    foreach (Symptom oSymptom in value)
                        AddSymptoms(oSymptom);
                }
            }
        }

        /// <summary>
        /// Add a new Symptom in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSymptoms(Symptom newSymptom)
        {
            if (newSymptom == null)
                return;
            if (_symptoms == null)
                _symptoms = new List<Symptom>();
            if (!_symptoms.Contains(newSymptom))
                _symptoms.Add(newSymptom);
        }

        /// <summary>
        /// Remove an existing Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSymptoms(Symptom oldSymptom)
        {
            if (oldSymptom == null)
                return;
            if (_symptoms != null)
                if (_symptoms.Contains(oldSymptom))
                    _symptoms.Remove(oldSymptom);
        }

        /// <summary>
        /// Remove all instances of Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSymptoms()
        {
            if (_symptoms != null)
                _symptoms.Clear();
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