using System.Collections.Generic;
using Xunit;
using Shouldly;
using Backend.Model.UserModel;
using System;
using Backend.Model.PatientModel;
using Backend.Util;

namespace WebApplicationTests.Unit.Scheduling
{
    public class TimeTableAppointmentSchedulingTests
    {
        [Fact]
        public void Get_shift_by_date()
        {
            TimeTable timeTable = TimeTableData();

            Shift shift = timeTable.GetShiftByDate(new DateTime(2022, 12, 20));

            shift.GetId().ShouldBe(1);
        }

        [Theory]
        [MemberData(nameof(IntervalData))]
        public void Get_available_times_for_interval(DateTime startTime, DateTime endTime, int timesCount)
        {
            TimeTable timeTable = TimeTableData();
            long durationInMinutes = 30;

            List<DateTime> availableTimes = timeTable.GetAvailableTimesForInterval(durationInMinutes, startTime, endTime);

            availableTimes.Count.ShouldBeEquivalentTo(timesCount);
        }

        [Fact]
        public void No_first_available_time_in_interval()
        {
            TimeTable timeTable = TimeTableData();
            long durationInMinutes = 30;

            List<DateTime> availableTime = timeTable.GetFirstAvailableTimeForInterval(durationInMinutes, new DateTime(2020, 12, 28), new DateTime(2020, 12, 30));

            availableTime.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Get_first_available_time()
        {
            TimeTable timeTable = TimeTableData();
            long durationInMinutes = 30;

            List<DateTime> availableTime = timeTable.GetFirstAvailableTimeForInterval(durationInMinutes, new DateTime(2022, 12, 19), new DateTime(2022, 12, 30));

            availableTime.Count.ShouldBe(1);
            availableTime[0].Minute.ShouldBe(0);
            availableTime[0].Hour.ShouldBe(10);
        }

        [Fact]
        public void Get_first_ten_appointments_or_less()
        {
            TimeTable timeTable = TimeTableData();
            long durationInMinutes = 30;

            List<DateTime> availableTimes = timeTable.GetFirstTenAppointments(durationInMinutes);

            availableTimes.Count.ShouldBe(6);
        }

        [Fact]
        public void Get_active_shifts()
        {
            TimeTable timeTable = TimeTableData();

            List<Shift> activeShifts = timeTable.GetActiveShifts();

            activeShifts.Count.ShouldBe(3);
        }

        [Theory]
        [MemberData(nameof(IntervalShiftData))]
        public void Get_active_shifts_in_interval(DateTime startTime, DateTime endTime, int shiftCount)
        {
            TimeTable timeTable = TimeTableData();

            List<Shift> activeShifts = timeTable.GetActiveShiftsInInterval(startTime, endTime);

            activeShifts.Count.ShouldBe(shiftCount);
        }

        private TimeTable TimeTableData()
            => new TimeTable(1, new List<Shift>
            {
                ShiftData(new DateTime(2022, 12, 20), 1),
                ShiftData(new DateTime(2022, 12, 21), 2),
                ShiftData(new DateTime(2022, 12, 22), 3)
            });

        private Shift ShiftData(DateTime date, long id)
        {
            ShiftType shiftType = new ShiftType(1, "First Shift", new DateTime(2022, 12, 20, 8, 0, 0), new DateTime(2022, 12, 20, 12, 0, 0));
            Shift shift = new Shift(id, date, shiftType, FillAppointmentList());
            return shift;
        }

        private List<Appointment> FillAppointmentList()   //free appointments: 10:00-10:30 and 11:00-11:30
            => new List<Appointment>
            {
                new Appointment(1, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 8, 0, 0), new DateTime(2022, 12, 20, 8, 30, 0))),
                new Appointment(2, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 8, 30, 0), new DateTime(2022, 12, 20, 9, 0, 0))),
                new Appointment(3, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 9, 00, 0), new DateTime(2022, 12, 20, 9, 30, 0))),
                new Appointment(4, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 9, 30, 0), new DateTime(2022, 12, 20, 10, 0, 0))),
                new Appointment(5, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 10, 30, 0), new DateTime(2022, 12, 20, 11, 0, 0))),
                new Appointment(6, null, null, null, 0, new TimeInterval(new DateTime(2022, 12, 20, 11, 30, 0), new DateTime(2022, 12, 20, 12, 0, 0)))
            };

        public static IEnumerable<object[]> IntervalData =>
        new List<object[]>
        {
            new object[] { new DateTime(2020, 12, 28), new DateTime(2020, 12, 30), 0 },
            new object[] { new DateTime(2022, 12, 19), new DateTime(2022, 12, 30), 4 },
            new object[] { new DateTime(2022, 12, 21), new DateTime(2022, 12, 22), 4 }
        };

        public static IEnumerable<object[]> IntervalShiftData =>
        new List<object[]>
        {
            new object[] { new DateTime(2020, 12, 28), new DateTime(2020, 12, 30), 0 },
            new object[] { new DateTime(2022, 12, 19), new DateTime(2022, 12, 30), 3 },
            new object[] { new DateTime(2022, 12, 21), new DateTime(2022, 12, 22), 2 }
        };

    }
}
