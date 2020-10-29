// File:    Feedback.cs
// Author:  Geri
// Created: 18. april 2020 20:34:11
// Purpose: Definition of Class Feedback

using System;
using System.Collections.Generic;
using SIMS.Repository.Abstract;

namespace SIMS.Model.UserModel
{
    public class Feedback : IIdentifiable<long>
    {
        private long _id;
        private User _user;
        private Dictionary<Question, Rating> _rating;
        private string _comment;

        public Feedback(User user, string comment)
        {
            _user = user;
            _comment = comment;
            _rating = new Dictionary<Question, Rating>();
        }

        public Feedback(long id, User user, string comment)
        {
            _id = id;
            _user = user;
            _comment = comment;
            _rating = new Dictionary<Question, Rating>();
        }

        public Feedback(User user,string comment, Dictionary<Question, Rating> rating)
        {
            _user = user;
            _comment = comment;
            if (rating == null)
                _rating = new Dictionary<Question, Rating>();
            else
                _rating = rating;
        }

        public Feedback(long id, User user, string comment, Dictionary<Question, Rating> rating)
        {
            _id = id;
            _user = user;
            _comment = comment;
            if (rating == null)
                _rating = new Dictionary<Question, Rating>();
            else
                _rating = rating;
        }

        public Feedback(long id)
        {
            _id = id;
            _rating = new Dictionary<Question, Rating>();
        }

   
        public User User { get => _user; set => _user = value; }

        public string Comment { get => _comment; set => _comment = value; }

        public Dictionary<Question, Rating> Rating
        {
            get
            {
                if (_rating == null)
                    _rating = new Dictionary<Question, Rating>();
                return _rating;
            }
            set
            {
                RemoveAllRating();
                if (value != null)
                {
                    foreach (Question q in value.Keys)
                        AddRating(q, value[q]);
                }
            }
        }

        public void AddRating(Question q, Rating r)
        {
            if (q == null)
                return;
            if (r == null)
                r = new Rating();
            if (_rating == null)
                _rating = new Dictionary<Question, Rating>();
            if (!_rating.ContainsKey(q))
                _rating.Add(q, r);
        }

        public void RemoveRating(Question q)
        {
            if (q == null)
                return;
            if (_rating != null)
                if (_rating.ContainsKey(q))
                    _rating.Remove(q);
        }

        public void RemoveAllRating()
        {
            if (_rating != null)
                _rating.Clear();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;

        public override bool Equals(object obj)
        {
            var feedback = obj as Feedback;
            return feedback != null &&
                   _id == feedback._id;
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }
    }
}