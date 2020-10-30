// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using Backend.Model.UserModel;
using Backend.Repository.Abstract.UsersAbstractRepository;
using Backend.Repository.CSVFileRepository.Csv;
using Backend.Repository.CSVFileRepository.Csv.IdGenerator;
using Backend.Repository.CSVFileRepository.Csv.Stream;
using Backend.Repository.Sequencer;
using System;
using System.Linq;

namespace Backend.Repository.CSVFileRepository.UsersRepository
{
    public class UserRepository : CSVRepository<User, UserID>, IUserRepository
    {
        private const string ENTITY_NAME = "User";

        public UserRepository(ICSVStream<User> stream, ISequencer<UserID> sequencer)
            : base(ENTITY_NAME, stream, sequencer, new UserIdGeneratorStrategy())
        {
        }

        public new User Create(User user)
        {
            throw new IllegalUserCreationException();
        }

        public User AddUser(User user)
        {
            _stream.AppendToFile(user);
            return user;
        }

        public User GetByUsername(string username)
            => _stream.ReadAll().SingleOrDefault(user => user.UserName.Equals(username));

    }
}