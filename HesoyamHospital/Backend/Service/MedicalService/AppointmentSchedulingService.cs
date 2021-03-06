﻿using Backend.Model.DoctorModel;
using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using Backend.Repository.Abstract.MedicalAbstractRepository;
using Backend.Repository.Abstract.UsersAbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.DTOs;

namespace Backend.Service.MedicalService
{
    public class AppointmentSchedulingService : IAppointmentSchedulingService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IDoctorRepository doctorRepository;
        public readonly long APPOINTMENT_DURATION_MINUTES = 30;

        public AppointmentSchedulingService(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            this.doctorRepository = doctorRepository;
            this.appointmentRepository = appointmentRepository;
        }

        public Appointment Create(Appointment entity)
        {
            return appointmentRepository.Create(entity);
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsByType(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriorityIntervalDTO> GetRecommendedTimes(PriorityIntervalDTO dto)
        {
            Doctor doctor = doctorRepository.GetByID(dto.DoctorId);
            if (doctor == null || doctor.TimeTable == null)
            {
                return GetByPriority(dto).ToList();
            }
            List<DateTime> appointments = doctor.TimeTable.GetAllAvailableTimesForInterval(APPOINTMENT_DURATION_MINUTES, dto.StartTime, dto.EndTime);
            if (appointments != null && appointments.Count != 0) return PriorityIntervalMapper.ListToDtoListForOneDoctor(doctor, appointments);
            return GetByPriority(dto).ToList();
        }

        public PriorityIntervalDTO GetAvailableTermsForEmergencyExamination(PriorityIntervalDTO dto, DoctorType specialisation)
        {
            return FindTermInNext30Minutes(GetWhenPriorityIsInterval(dto, specialisation).ToList());
        }

        public PriorityIntervalDTO FindTermInNext30Minutes(List<PriorityIntervalDTO> intervals)
        {
            foreach (PriorityIntervalDTO i in intervals)   
                if ((i.StartTime - DateTime.Now).TotalMinutes <= 30) 
                    return i;

            return null;
        }

        public IEnumerable<PriorityIntervalDTO> GetByPriority(PriorityIntervalDTO dto)
        {
            if (dto.Priority) return GetWhenPriorityIsDoctor(dto);

            return GetWhenPriorityIsInterval(dto, doctorRepository.GetByID(dto.DoctorId).Specialisation);
        }


        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsDoctor(PriorityIntervalDTO dto)
        {
            Doctor doctor = doctorRepository.GetByID(dto.DoctorId);
            if (doctor == null || doctor.TimeTable == null)
            {
                return new List<PriorityIntervalDTO>();
            }     
            List<DateTime> appointments = doctor.TimeTable.GetAllAvailableAppointments(APPOINTMENT_DURATION_MINUTES).ToList();
            if (appointments != null && appointments.Count != 0)
            {
                return PriorityIntervalMapper.ListToDtoListForOneDoctor(doctor, appointments);
            }   
            return new List<PriorityIntervalDTO>();
        }

        public IEnumerable<PriorityIntervalDTO> GetWhenPriorityIsInterval(PriorityIntervalDTO dto, DoctorType doctorType)
        {
            List<PriorityIntervalDTO> appointments = new List<PriorityIntervalDTO>();
            List<Doctor> doctors = doctorRepository.GetDoctorByType(doctorType).ToList();
            if (doctors == null || doctors.Count == 0)
            {
                return appointments;
            }
            foreach (Doctor d in doctors)
            {
                if (d == null || d.TimeTable == null)
                    break;

                dto.DoctorId = d.Id;
                appointments.AddRange(PriorityIntervalMapper.ListToDtoListForOneDoctor(d, d.TimeTable.GetAvailableTimesForInterval(APPOINTMENT_DURATION_MINUTES, dto.StartTime, dto.EndTime).ToList()));
            }
            return appointments;
        }
        public IEnumerable<DateTime> GetTimesForDoctorAndDate(long id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetTimesForSelectedDoctor(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool MultipleAppoitments(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            if (appointment.DoctorInAppointment == null || appointment.DoctorInAppointment.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime) == null) return null;
            appointment.DoctorInAppointment.TimeTable.GetShiftByDate(appointment.TimeInterval.StartTime).Appointments.Add(appointment);
            doctorRepository.UpdateProperty(appointment.DoctorInAppointment, "TimeTable");
            return appointment;
        }


        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Appointment entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
