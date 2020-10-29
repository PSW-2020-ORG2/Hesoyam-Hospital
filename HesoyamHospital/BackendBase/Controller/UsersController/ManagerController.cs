// File:    ManagerController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class ManagerController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service;
using SIMS.Service.UsersService;

namespace SIMS.Controller.UsersController
{
    public class ManagerController : IController<Manager, UserID>
    {

        public ManagerService managerService;


        public ManagerController(ManagerService service)
        {
            managerService = service;
        }

        public Manager Create(Manager manager)
            => managerService.Create(manager);

        public void Delete(Manager manager)
            => managerService.Delete(manager);

        public IEnumerable<Manager> GetAll()
            => managerService.GetAll();

        public Manager GetByID(UserID id)
            => managerService.GetByID(id);

        public void Update(Manager manager)
            => managerService.Update(manager);

    }
}