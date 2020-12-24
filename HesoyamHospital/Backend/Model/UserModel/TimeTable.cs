using Backend.Repository.Abstract;
using System;
using System.Collections.Generic;

namespace Backend.Model.UserModel
{
    public class TimeTable : IIdentifiable<long>
    {
        public long Id { get; set; }
        public virtual List<Shift> Shifts { get; set; }

        public TimeTable(List<Shift> shifts)
        {
            Shifts = shifts;
        }

        public TimeTable(long id, List<Shift> shifts)
        {
            Id = id;
            Shifts = shifts;
        }

        public TimeTable()
        {
            Shifts = new List<Shift>();
        }

        public TimeTable(long id)
        {
            Id = id;
        }

        public Shift GetShiftByDate(DateTime dateTime)
        {
            foreach (Shift shift in Shifts)
            {
                if (shift.Date.Year == dateTime.Year && shift.Date.Month == dateTime.Month && shift.Date.Day == dateTime.Day && shift.IsActive()) return shift;
            }
            return null;
        }

        public List<DateTime> GetFirstAvailableTimeForInterval(long duration, DateTime startDate, DateTime endDate)
        {
            List<DateTime> appointments = new List<DateTime>();
            List<Shift> activeShiftsInInterval = GetActiveShiftsInInterval(startDate, endDate);
            foreach (Shift shift in activeShiftsInInterval)
            {
                if (shift.HasAvailableAppointment(duration))
                {
                    appointments.Add(shift.GetFirstAvailableTime(duration));
                    return appointments;
                }
            }
            return appointments;
        }

        public List<DateTime> GetAvailableTimesForInterval(long duration, DateTime startDate, DateTime endDate)
        {
            List<DateTime> appointments = new List<DateTime>();
            List<Shift> activeShiftsInInterval = GetActiveShiftsInInterval(startDate, endDate);
            foreach (Shift shift in activeShiftsInInterval)
            {
                AddToList(appointments, shift.GetAvailableTimes(duration));
                if (appointments.Count >= 3) return appointments;
            }
            return appointments;
        }

        public List<DateTime> GetAllAvailableTimesForInterval(long duration, DateTime startDate, DateTime endDate)
        {
            List<DateTime> appointments = new List<DateTime>();
            List<Shift> activeShiftsInInterval = GetActiveShiftsInInterval(startDate, endDate);
            foreach (Shift shift in activeShiftsInInterval)
            {
                appointments.AddRange(shift.GetAvailableTimes(duration));
                
            }
            return appointments;
        }

        public List<DateTime> GetFirstTenAppointments(long duration)
        {
            List<DateTime> appointments = new List<DateTime>();
            List<Shift> activeShifts = GetActiveShifts();
            foreach (Shift shift in activeShifts)
            {
                AddToList(appointments, shift.GetAvailableTimes(duration));
                if (appointments.Count >= 10) return appointments;
            }
            return appointments;
        }

        public List<DateTime> GetAllAvailableAppointments(long duration)
        {
            List<DateTime> appointments = new List<DateTime>();
            List<Shift> activeShifts = GetActiveShifts();
            foreach (Shift shift in activeShifts)
            {
                AddToList(appointments, shift.GetAvailableTimes(duration));
            }
            return appointments;
        }

        private List<DateTime> AddToList(List<DateTime> appointments, List<DateTime> newAvailable)
        {
            foreach (DateTime dateTime in newAvailable)
            {
                if (appointments.Count >= 10) return appointments;
                appointments.Add(dateTime);
            }
            return appointments;
        }

        public List<Shift> GetActiveShifts()
        {
            List<Shift> activeShifts = new List<Shift>();
            foreach (Shift shift in Shifts)
            {
                if (shift.IsActive()) activeShifts.Add(shift);
            }
            return activeShifts;
        }

        public List<Shift> GetActiveShiftsInInterval(DateTime startTime, DateTime endTime)
        {
            List<Shift> activeShifts = GetActiveShifts();
            List<Shift> activeShiftsInInterval = new List<Shift>();
            foreach (Shift shift in activeShifts)
            {
                if (shift.IsShiftInInterval(startTime, endTime)) activeShiftsInInterval.Add(shift);
            }
            return activeShiftsInInterval;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public override bool Equals(object obj)
        {
            var table = obj as TimeTable;
            return table != null &&
                   Id == table.Id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }
    }
}