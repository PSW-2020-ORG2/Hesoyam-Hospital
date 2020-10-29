// File:    StatisticsController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class StatisticsController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;

namespace SIMS.Controller.HospitalManagementController
{
    public class StatisticsController : IController<Stats, long>
    {

        

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
        {
            throw new NotImplementedException();
        }

        public Doctor GetStatisticsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public StatsRoom GetStatisticsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsRoom> GetRoomStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stats> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stats GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Stats Create(Stats entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Stats entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Stats entity)
        {
            throw new NotImplementedException();
        }

    }
}