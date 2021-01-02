using System;

namespace Documents.Util
{
    public class TimeInterval
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeInterval() { }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsDateTimeBetween(DateTime dateTime)
            => StartTime < dateTime && EndTime > dateTime;

        public bool IsDateTimeBetween(TimeInterval timeInterval)
        {
            return (timeInterval.StartTime >= StartTime) && (timeInterval.EndTime <= EndTime);
        }

        public bool IsTimeBetween(TimeInterval timeInterval)
        {
            DateTime compareStart = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, timeInterval.StartTime.Hour, timeInterval.StartTime.Minute, timeInterval.StartTime.Second);
            DateTime compareEnd = new DateTime(EndTime.Year, EndTime.Month, EndTime.Day, timeInterval.EndTime.Hour, timeInterval.EndTime.Minute, timeInterval.EndTime.Second);
            return (compareStart >= StartTime) && (compareEnd <= EndTime);
        }

        public bool IsOverlappingWith(TimeInterval timeInterval)
        {
            return ((StartTime < timeInterval.EndTime) && (EndTime > timeInterval.StartTime));
        }

        public TimeSpan Duration()
            => EndTime.Subtract(StartTime);

        public bool IsFullyDefined()
        {   
            if (StartTime != null && EndTime != null)
            {
                return true;
            }
            return false;
        }

        public bool IsInOrder()
            => EndTime >= StartTime;

        public bool IsInThePast()
            => StartTime <= DateTime.Now && EndTime <= DateTime.Now;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TimeInterval otherTime = obj as TimeInterval;
            return StartTime.Equals(otherTime.StartTime) && EndTime.Equals(otherTime.EndTime);
        }

        public override int GetHashCode()
        {
            return 1969571243 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return StartTime.ToString() + " - " + EndTime.ToString();
        }
    }
}