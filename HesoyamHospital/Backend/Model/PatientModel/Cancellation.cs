using Backend.Repository.Abstract;
using System;

namespace Backend.Model.PatientModel
{
    public class Cancellation : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual Appointment Appointment { get; set; }
        public DateTime DateCancelled { get; set; }

        public Cancellation(long id)
        {
            Id = id;
        }

        public Cancellation(long id, Appointment appointment, DateTime dateCancelled)
        {
            Id = id;
            Appointment = appointment;
            DateCancelled = dateCancelled;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
