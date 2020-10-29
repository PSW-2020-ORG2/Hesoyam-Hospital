// File:    ManagerService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class ManagerService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Exceptions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Util;

namespace SIMS.Service.UsersService
{
    public class ManagerService : IService<Manager, UserID>
    {
        ManagerRepository _managerRepository;
        UserValidation _userValidation;

        public ManagerService(ManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
            _userValidation = new UserValidation();
        }

        public Manager Create(Manager entity)
        {
            Validate(entity);
            return _managerRepository.Create(entity);
        }

        public void Delete(Manager entity)
            => _managerRepository.Delete(entity);

        public IEnumerable<Manager> GetAll()
            => _managerRepository.GetAll();

        public Manager GetByID(UserID id)
            => _managerRepository.GetByID(id);

        public void Validate(Manager user)
            => _userValidation.Validate(user);

        public void Update(Manager entity)
        {
            Validate(entity);
            _managerRepository.Update(entity);
        }
    }
}