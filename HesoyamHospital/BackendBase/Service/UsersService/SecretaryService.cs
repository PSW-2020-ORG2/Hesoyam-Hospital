// File:    SecretaryService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Exceptions;
using SIMS.Util;

namespace SIMS.Service.UsersService
{
    public class SecretaryService : IService<Secretary, UserID>
    {
        SecretaryRepository _secretaryRepository;
        UserValidation _userValidation;

        public SecretaryService(SecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
            _userValidation = new UserValidation();
        }

        public Secretary Create(Secretary entity)
        {
            Validate(entity);
            return _secretaryRepository.Create(entity);
        }

        public void Delete(Secretary entity)
            => _secretaryRepository.Delete(entity);

        public IEnumerable<Secretary> GetAll()
            => _secretaryRepository.GetAllEager();

        public Secretary GetByID(UserID id)
            => _secretaryRepository.GetByID(id);

        public void Validate(Secretary user)
            => _userValidation.Validate(user);

        public void Update(Secretary entity)
        {
            Validate(entity);
            _secretaryRepository.Update(entity);
        }
    }
}