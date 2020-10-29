// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
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