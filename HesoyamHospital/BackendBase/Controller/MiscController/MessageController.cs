// File:    MessageController.cs
// Author:  nikola
// Created: 22. maj 2020 17:31:54
// Purpose: Definition of Class MessageController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class MessageController : IController<Message, long>
    {

        private MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        public IEnumerable<Message> GetSent(User user)
            => _messageService.GetSent(user);

        public IEnumerable<Message> GetRecieved(User user)
            => _messageService.GetRecieved(user);

        public IEnumerable<Message> GetAll()
            => _messageService.GetAll();

        public Message GetByID(long id)
            => _messageService.GetByID(id);

        public Message Create(Message entity)
            => _messageService.Create(entity);

        public void Update(Message entity)
            => _messageService.Update(entity);

        public void Delete(Message entity)
            => _messageService.Delete(entity);

    }
}