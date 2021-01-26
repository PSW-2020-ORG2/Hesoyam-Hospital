using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Service.MedicalService;
using Backend.Util;
using GraphicEditor;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphicEditorTests.Integration
{
    public class CancelAppointmentTest
    {
        [Fact]
        public void CancelAppointment()
        {
            AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;
            Appointment appointment = appointmentService.GetByID(4);
            appointmentService.CancelAppointment(appointment);
            Appointment appointmentAfter = appointmentService.GetByID(4);
            appointmentAfter.Canceled.ShouldBe(true);

        }
    }
}
