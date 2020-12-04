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

        public List<DateTime> GetAvailableTimes(long durationInMinutes)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            DateTime emptyAppointment = new DateTime(Date.Year, Date.Month, Date.Day, ShiftType.StartTime.Hour, ShiftType.StartTime.Minute, 0);

            while(!TimesAreEqual(emptyAppointment, ShiftType.EndTime))
            {
                if(!AppointmentExists(emptyAppointment))
                {
                    dateTimes.Add(emptyAppointment);
                }
                emptyAppointment = emptyAppointment.AddMinutes(durationInMinutes);
            }
            return dateTimes;
        }

        private bool TimesAreEqual(DateTime firstTime, DateTime secondTime)
        {
            if (firstTime.Hour == secondTime.Hour && firstTime.Minute == secondTime.Minute) return true;
            return false;
        }

        private bool AppointmentExists(DateTime startTime)
        {
            foreach (Appointment appointment in Appointments)
            {
                if (TimesAreEqual(appointment.TimeInterval.StartTime, startTime)) return true;
            }
            return false;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}
