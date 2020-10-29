// File:    SecretaryController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class SecretaryController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.UsersService;

namespace SIMS.Controller.UsersController
{
    public class SecretaryController : IController<Secretary, UserID>
    {
        public SecretaryService secretaryService;

        public SecretaryController(SecretaryService service)
        {
            secretaryService = service;
        }

        public Secretary Create(Secretary secretary)
            => secretaryService.Create(secretary);

        public void Delete(Secretary secretary)
            => secretaryService.Delete(secretary);

        public IEnumerable<Secretary> GetAll()
            => secretaryService.GetAll();

        public Secretary GetByID(UserID id)
            => secretaryService.GetByID(id);

        public void Update(Secretary secretary)
            => secretaryService.Update(secretary);
    }
}