using System;

namespace Appointments.Model.ScheduleModel
{
    public class Cancellation
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

        public bool InPreviousMonth()
        {
            DateTime beforeOneMonth = DateTime.Now.AddDays(-30);
            if (DateCancelled >= beforeOneMonth) return true;
            return false;
        }
    }
}
