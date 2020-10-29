// File:    IStatisticsRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:58:07
// Purpose: Definition of Interface IStatisticsRepository

using System;
using System.Collections.Generic;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IStatisticsRepository : IRepository<Stats, long>
    {
        IEnumerable<StatsDoctor> GetDoctorStatistics();

        Doctor GetStatisticsByDoctor(Doctor doctor);

        StatsInventory GetStatisticsByItem(Item item);

        StatsRoom GetStatisticsByRoom(Room room);

        IEnumerable<StatsRoom> GetRoomStatistics();

        StatsInventory GetInventoryStatistics();

    }
}