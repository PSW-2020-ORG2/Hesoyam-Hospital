using Xunit;
using System;
using System.Collections.Generic;
using Backend.Service.MedicalService;
using Shouldly;
using Backend.DTOs;
using Backend.Model.UserModel;
using Backend.Repository.MySQLRepository.HospitalManagementRepository;
using Backend.Repository.MySQLRepository.UsersRepository;

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
        [Fact]
        public void recommend_appointments_priority_doctor()
        {
            AppointmentSchedulingService appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            var priorityInterval = new PriorityIntervalDTO(new DateTime(2020, 12, 28), new DateTime(2021, 1, 2), "Ivan Ivanovic", 101, true);
            List<PriorityIntervalDTO> appointments = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            appointments.ShouldNotBeNull();
        }
        [Fact]
        public void recommend_appointments_priority_interval()
        {
            AppointmentSchedulingService appointmentSchedulingService = Backend.AppResources.getInstance().appointmentSchedulingService;
            var priorityInterval = new PriorityIntervalDTO(new DateTime(2020, 12, 28), new DateTime(2021, 1, 2), "Ivan Ivanovic", 101, false);
            List<PriorityIntervalDTO> appointments = (List<PriorityIntervalDTO>)appointmentSchedulingService.GetRecommendedTimes(priorityInterval);
            appointments.ShouldNotBeNull();
        }
        [Fact]
        public void get_no_available_terms_for_interval()
        {
            DoctorRepository doctorRepository = Backend.AppResources.getInstance().doctorRepository;
            Doctor doctor = doctorRepository.GetByID(101);
            List<DateTime> appointments = doctor.TimeTable.GetAllAvailableTimesForInterval(30, new DateTime(2020, 12, 28), new DateTime(2021, 1, 2));
            Assert.Empty(appointments);
        }


    }
}
