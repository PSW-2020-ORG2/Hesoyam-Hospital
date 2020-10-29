// File:    Message.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Message

using System;

namespace SIMS.Model.UserModel
{
    public class Message : Content
    {
        private bool _opened;
        private User _recipient;
        private User _sender;

        public Message(string text, User recipient, User sender) : base(text)
        {
            _opened = false;
            _recipient = recipient;
            _sender = sender;
        }

        public Message(long id, string text, User recipient, User sender, DateTime dateCreated) : base(id, text, dateCreated)
        {
            _opened = false;
            _recipient = recipient;
            _sender = sender;
        }

        public Message(long id, string text, User recipient, User sender, DateTime dateCreated, bool opened) : base(id, text, dateCreated)
        {
            _opened = opened;
            _recipient = recipient;
            _sender = sender;
        }

        public Message(long id) : base(id) { }

        public bool Opened { get => _opened; set => _opened = value; }
        public User Recipient { get => _recipient; set { _recipient = value; } }
        public User Sender { get => _sender; set { _sender = value; } }
    }
}