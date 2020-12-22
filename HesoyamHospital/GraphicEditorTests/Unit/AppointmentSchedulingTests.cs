using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Service.MedicalService;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Shouldly;

namespace GraphicEditorTests.Unit
{
    public class AppointmentSchedulingTests
    {

        [Fact]
        public void reccomend_appointments()
        {
            AppointmentSchedulingService appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            var priorityInterval = new PriorityIntervalDTO(new DateTime(2020,12,28),new DateTime(2021,2,2),"Ivan",true);
            List<Appointment>appointments = (List<Appointment>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            appointments.ShouldNotBeNull();
        }

    }
}
