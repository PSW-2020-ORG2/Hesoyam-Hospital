using Xunit;
using System;
using System.Collections.Generic;
using Backend.Service.MedicalService;
using Shouldly;
using Backend.DTOs;


namespace GraphicEditorTests.Unit
{
    public class AppointmentSchedulingTests
    {
        [Fact]
        public void recommend_appointments()
        {
            AppointmentSchedulingService appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            var priorityInterval = new PriorityIntervalDTO(new DateTime(2020,12,28),new DateTime(2021,2,2),"Ivan Ivanovic",101,true);
            List<PriorityIntervalDTO>appointments = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            appointments.ShouldNotBeNull();
        }

    }
}
