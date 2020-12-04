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
                if (shift.Date.Date == dateTime.Date) return shift;
            }
            return null;
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