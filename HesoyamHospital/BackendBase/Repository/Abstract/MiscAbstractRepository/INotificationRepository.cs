// File:    INotificationRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:08:15
// Purpose: Definition of Interface INotificationRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface INotificationRepository : IRepository<Notification, long>
    {
        IEnumerable<Notification> GetNotificationByUser(User user);

    }
}