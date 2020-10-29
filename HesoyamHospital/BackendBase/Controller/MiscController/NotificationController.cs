// File:    NotificationController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class NotificationController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class NotificationController : IController<Notification, long>
    {

        public NotificationService notificationService;

        public NotificationController(NotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => notificationService.GetNotificationByUser(user);

        public IEnumerable<Notification> GetAll()
            => notificationService.GetAll();

        public Notification GetByID(long id)
            => notificationService.GetByID(id);

        public Notification Create(Notification entity)
            => notificationService.Create(entity);

        public void Update(Notification entity)
            => notificationService.Update(entity);

        public void Delete(Notification entity)
            => notificationService.Delete(entity);

    }
}