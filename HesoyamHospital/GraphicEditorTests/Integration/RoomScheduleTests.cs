using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Service.MedicalService;
using Backend.Util;
using GraphicEditor;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GraphicEditorTests.Unit
{
    public class RoomScheduleTests
    {
        [Fact]
        public void Get_appointments_by_room()
        {
            AppointmentService appointmentService = Backend.AppResources.getInstance().appointmentService;
            Room room = new Room(101);
            List<Appointment> appointments = (List<Appointment>)appointmentService.GetAppointmentsByRoom(room);
            appointments.ShouldNotBeNull();

        }

    }
}
