using Backend.Model.PatientModel;
using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;

namespace Backend.Model.UserModel
{
    public class Shift : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ShiftType ShiftType { get; set; }
        public virtual List<Appointment> Appointments { get; set; }

        public Shift(long id)
        {
            Id = id;
        }
        public Shift(long id, DateTime date, ShiftType shiftType, List<Appointment> appointments)
        {
            Id = id;
            Date = date;
            ShiftType = shiftType;
            Appointments = appointments;
        }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
