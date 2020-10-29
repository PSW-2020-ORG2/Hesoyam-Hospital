// File:    Prescription.cs
// Author:  nikola
// Created: 21. maj 2020 15:43:46
// Purpose: Definition of Class Prescription

using SIMS.Model.PatientModel;
using System;
using SIMS.Repository.Abstract;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Model.PatientModel
{
    public class Prescription : IIdentifiable<long>
   {
        private long _id;
        private PrescriptionStatus _status;
        private Doctor _doctor;
        private Dictionary<Medicine,TherapyDose> _medicine;

        public Prescription(long id)
        {
            _id = id;
        }
        public Prescription(long id, PrescriptionStatus status, Doctor doctor,Dictionary<Medicine, TherapyDose> medicine)
        {
            _id = id;
            _status = status;
            _doctor = doctor;
            _medicine = medicine;
        }

        public Prescription(PrescriptionStatus status, Doctor doctor,Dictionary<Medicine,TherapyDose> medicine)
        {
            _status = status;
            _doctor = doctor;
            _medicine = medicine;
        }

        public Prescription(Dictionary<Medicine, TherapyDose> medicines)
        {
            _status = PrescriptionStatus.ACTIVE;
            _medicine = medicines;
        }


      
      /// <summary>
      /// Property for collection of Medicine
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public Dictionary<Medicine, TherapyDose> Medicine
      {
         get
         {
                if (_medicine == null)
                    _medicine = new Dictionary<Medicine, TherapyDose>();
            return _medicine;
         }
         set
         {
            RemoveAllMedicine();
            if (value != null)
            {
               foreach (Medicine oMedicine in value.Keys)
                  AddMedicine(oMedicine, _medicine[oMedicine]);
            }
         }
      }

        public PrescriptionStatus Status { get => _status; set => _status = value; }
        public Doctor Doctor { get => _doctor; set => _doctor = value; }

        /// <summary>
        /// Add a new Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddMedicine(Medicine newMedicine,TherapyDose therapyDose)
      {
         if (newMedicine == null)
            return;
         if (this._medicine == null)
            this._medicine = new Dictionary<Medicine, TherapyDose>();
         if (!this._medicine.ContainsKey(newMedicine))
            this._medicine.Add(newMedicine, therapyDose);
      }
      
      /// <summary>
      /// Remove an existing Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveMedicine(Medicine oldMedicine)
      {
         if (oldMedicine == null)
            return;
         if (this._medicine != null)
            if (this._medicine.ContainsKey(oldMedicine))
               this._medicine.Remove(oldMedicine);
      }
      
      /// <summary>
      /// Remove all instances of Medicine from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllMedicine()
      {
         if (_medicine != null)
            _medicine.Clear();
      }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public override bool Equals(object obj)
        {
            var prescription = obj as Prescription;
            return prescription != null &&
                   _id == prescription._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}