// File:    Article.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Article

using System;

namespace SIMS.Model.UserModel
{
    public class Article : Content
    {
        private string _title;
        private string _shortDescription;

        public Employee _author;

        public Article(string title, string shortDescription, string text, Employee author, DateTime dateCreated) : base(text, dateCreated)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
        }

        public Article(string title, string shortDescription, string text, Employee author) : base(text)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
        }

        public Article(long id, string title, string shortDescription, string text, Employee author, DateTime dateCreated) : base(id, text, dateCreated)
        {
            _title = title;
            _shortDescription = shortDescription;
            _author = author;
        }

        public Article(long id) : base(id) { }

        public string Title { get => _title; set => _title = value; }
        public string ShortDescription { get { return _shortDescription; } }
        public Employee Author { get { return _author; } set { _author = value; } }
    }
}