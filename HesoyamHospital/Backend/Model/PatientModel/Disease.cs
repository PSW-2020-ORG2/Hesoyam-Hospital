/***********************************************************************
 * Module:  Disease.cs
 * Author:  nikola
 * Purpose: Definition of the Class Disease
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Backend.Repository.Abstract;

namespace Backend.Model.PatientModel
{
    public class Disease : IIdentifiable<long>
    {
        private long _id;
        public long Id { get => _id; set => _id = value; }
        private string _name;
        public string Name { get => _name; set => _name = value; }
        private string _overview;
        public string Overview { get => _overview; set => _overview = value; }

        private bool _isChronic;
        public bool IsChronic { get => _isChronic; set => _isChronic = value; }

        private long _diseaseTypeID;
        public long DiseaseTypeID
        {
            get { return _diseaseTypeID; }
            set { _diseaseTypeID = value; }
        }

        private DiseaseType _diseaseType;
        public DiseaseType DiseaseType
        {
            get { return _diseaseType; }
            set { _diseaseType = value; }
        }

        private List<Medicine> _administratedFor;

        public List<Medicine> AdministratedFor
        {
            get
            {
                if (_administratedFor == null)
                    _administratedFor = new List<Medicine>();
                return _administratedFor;
            }
            set
            {
                RemoveAllAdministratedFor();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddAdministratedFor(oMedicine);
                }
            }
        }
        private List<Symptom> _symptoms;
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






        public Disease(long id)
        {
            _id = id;
        }

        public Disease(long id, string name, string overview, bool isChronic, DiseaseType diseaseType, List<Symptom> symptoms, List<Medicine> administratedFor = null)
        {
            _id = id;
            _name = name;
            _overview = overview;
            _isChronic = isChronic;
            _diseaseTypeID = DiseaseType.Id;
           _diseaseType = diseaseType;
            _symptoms = symptoms;

            if (administratedFor == null)
                _administratedFor = new List<Medicine>();
            else
                _administratedFor = administratedFor;
        }

        public Disease(string name, string overview, bool isChronic, DiseaseType diseaseType,List<Symptom> symptoms,List<Medicine> administratedFor = null)
        {
            _name = name;
            _overview = overview;
            _isChronic = isChronic;
            _diseaseTypeID = DiseaseType.Id;
            _diseaseType = diseaseType;
            _symptoms = symptoms;

            if (administratedFor == null)
                _administratedFor = new List<Medicine>();
            else
                _administratedFor = administratedFor;
        }

        /// <summary>
        /// Property for DiseaseType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
       

        /// <summary>
        /// Property for collection of Medicine
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        

        /// <summary>
        /// Add a new Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAdministratedFor(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (_administratedFor == null)
                _administratedFor = new List<Medicine>();
            if (!_administratedFor.Contains(newMedicine))
            {
                _administratedFor.Add(newMedicine);
                newMedicine.AddUsedFor(this);
            }
        }

        /// <summary>
        /// Remove an existing Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAdministratedFor(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (_administratedFor != null)
                if (_administratedFor.Contains(oldMedicine))
                {
                    _administratedFor.Remove(oldMedicine);
                    oldMedicine.RemoveUsedFor(this);
                }
        }

        /// <summary>
        /// Remove all instances of Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAdministratedFor()
        {
            if (_administratedFor != null)
            {
                List<Medicine> tmpAdministratedFor = new List<Medicine>();
                foreach (Medicine oldMedicine in _administratedFor)
                    tmpAdministratedFor.Add(oldMedicine);
                _administratedFor.Clear();
                foreach (Medicine oldMedicine in tmpAdministratedFor)
                    oldMedicine.RemoveUsedFor(this);
                tmpAdministratedFor.Clear();
            }
        }


        /// <summary>
        /// Property for collection of Symptom
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        

       
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

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Disease otherDisease = obj as Disease;
            return _id == otherDisease.GetId();
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}