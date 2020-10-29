// File:    IMessageRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:22
// Purpose: Definition of Interface IMessageRepository

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.MiscAbstractRepository
{
    public interface IMessageRepository : IRepository<Message, long>
    {
        IEnumerable<Message> GetSent(User user);

        IEnumerable<Message> GetReceived(User user);

    }
}