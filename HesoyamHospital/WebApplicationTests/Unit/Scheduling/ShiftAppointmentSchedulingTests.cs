using System.Collections.Generic;
using Xunit;
using Shouldly;
using System;
using Appointments.Model;
using Appointments.Util;

namespace WebApplicationTests.Unit.Scheduling
{
    public class ShiftAppointmentSchedulingTests
    {
        [Fact]
        public void Get_available_times_for_shift()
        {
            Shift shift = ShiftData();
            long durationInMinutes = 30;

            List<DateTime> availableTimes = shift.GetAvailableTimes(durationInMinutes);

            availableTimes.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Shift_has_available_appointment()
        {
            Shift shift = ShiftData();
            long durationInMinutes = 30;

            shift.HasAvailableAppointment(durationInMinutes).ShouldBe(true);
        }

        [Fact]
        public void Get_first_available_appointment_in_shift()
        {
            Shift shift = ShiftData();
            long durationInMinutes = 30;

            DateTime availableTime = shift.GetFirstAvailableTime(durationInMinutes);

            availableTime.Minute.ShouldBe(0);
            availableTime.Hour.ShouldBe(10);
        }

        [Fact]
        public void Is_shift_active()
        {
            Shift shift = InactiveShiftData();
            shift.IsActive().ShouldBe(false);
        }

        private Shift ShiftData()
        {
            ShiftType shiftType = new ShiftType(1, "First Shift", new DateTime(2021, 12, 20, 8, 0, 0), new DateTime(2021, 12, 20, 12, 0, 0));
            Shift shift = new Shift(1, new DateTime(2021, 12, 20), shiftType, FillAppointmentList());
            return shift;
        }

        private Shift InactiveShiftData()
        {
            ShiftType shiftType = new ShiftType(1, "First Shift", new DateTime(2021, 12, 20, 8, 0, 0), new DateTime(2021, 12, 20, 12, 0, 0));
            Shift shift = new Shift(1, new DateTime(2020, 12, 20), shiftType, FillAppointmentList());
            return shift;
        }

        private List<Appointment> FillAppointmentList()   //free appointments: 10:00-10:30 and 11:00-11:30
            => new List<Appointment>
            {
                new Appointment(1, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 8, 0, 0), new DateTime(2022, 12, 20, 8, 30, 0))),
                new Appointment(2, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 8, 30, 0), new DateTime(2022, 12, 20, 9, 0, 0))),
                new Appointment(3, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 9, 00, 0), new DateTime(2022, 12, 20, 9, 30, 0))),
                new Appointment(4, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 9, 30, 0), new DateTime(2022, 12, 20, 10, 0, 0))),
                new Appointment(5, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 10, 30, 0), new DateTime(2022, 12, 20, 11, 0, 0))),
                new Appointment(6, 0, 0, 0, 0, new TimeInterval(new DateTime(2022, 12, 20, 11, 30, 0), new DateTime(2022, 12, 20, 12, 0, 0)))
            };
    }
}
