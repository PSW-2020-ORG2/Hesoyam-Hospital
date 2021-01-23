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
                if(!AppointmentExists(emptyAppointment) && IsAppointmentActive(emptyAppointment))
                {
                    dateTimes.Add(emptyAppointment);
                }
                emptyAppointment = emptyAppointment.AddMinutes(durationInMinutes);
            }
            return dateTimes;
        }

        public bool HasAvailableAppointment(long duration)
        {
            List<DateTime> availableAppointments = GetAvailableTimes(duration);
            if (availableAppointments == null || availableAppointments.Count == 0) return false;
            return true;
        }

        public DateTime GetFirstAvailableTime(long duration)
        {
            List<DateTime> availableAppointments = GetAvailableTimes(duration);
            return availableAppointments[0];
        }

        private bool TimesAreEqual(DateTime firstTime, DateTime secondTime)
        {
            if (firstTime.Hour == secondTime.Hour && firstTime.Minute == secondTime.Minute) return true;
            return false;
        }

        public bool IsActive()
        {
            if (Date.Year > DateTime.Now.Year) return true;
            if (Date.Year == DateTime.Now.Year && Date.Month > DateTime.Now.Month) return true;
            if (Date.Day >= DateTime.Now.Day && Date.Month == DateTime.Now.Month && Date.Year == DateTime.Now.Year) return true;
            return false;
        }

        public bool IsShiftInInterval(DateTime startTime, DateTime endTime)
        {
            if (IsGreaterOrEqual(startTime) && IsLessOrEqual(endTime)) return true;
            return false;
        }

        private bool IsGreaterOrEqual(DateTime startTime)
        {
            if (Date.Year > startTime.Year) return true;
            if (Date.Year == startTime.Year && Date.Month > startTime.Month) return true;
            if (Date.Year == startTime.Year && Date.Month == startTime.Month && Date.Day >= startTime.Day) return true;
            return false;
        }

        private bool IsLessOrEqual(DateTime endTime)
        {
            if (Date.Year < endTime.Year) return true;
            if (Date.Year == endTime.Year && Date.Month < endTime.Month) return true;
            if (Date.Year == endTime.Year && Date.Month == endTime.Month && Date.Day <= endTime.Day) return true;
            return false;
        }

        private bool IsAppointmentActive(DateTime startTime)
        {
            if (!IsCurrentDay()) return true;
            if (startTime.Hour > DateTime.Now.Hour) return true;
            if (startTime.Hour == DateTime.Now.Hour && startTime.Minute > DateTime.Now.Minute) return true;
            return false;
        }

        private bool IsCurrentDay()
        {
            if (Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month && Date.Year == DateTime.Now.Year) return true;
            return false;
        }

        public bool PatientAlreadyScheduledInThisShift(long patientId)
        {
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.Patient == null) break;
                if (appointment.Patient.Id == patientId && !appointment.Canceled) return true;
            }
            return false;
        }

        private bool AppointmentExists(DateTime startTime)
        {
            foreach (Appointment appointment in Appointments)
            {
                if (TimesAreEqual(appointment.TimeInterval.StartTime, startTime) && !appointment.Canceled) return true;
            }
            return false;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public object GetFirstTenAppointments(long aPPOINTMENT_DURATION_MINUTES)
        {
            throw new NotImplementedException();
        }
    }
}
