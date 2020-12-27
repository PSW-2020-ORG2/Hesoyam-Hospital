﻿using Appointments.DTOs;
using Authentication.Model.ScheduleModel;
using Authentication.Model.UserModel;
using System;
using System.Collections.Generic;

namespace Appointments.Service.Abstract
{
    public interface IAppointmentSchedulingService : IService<Appointment, long>
    {
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date);
        public List<Doctor> GetDoctorsByType(string type);
        public Appointment SaveAppointment(Appointment appointment);
        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient);
        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityDTO dto);
        public bool MultipleAppoitments(AppointmentDTO dto);
    }
}
