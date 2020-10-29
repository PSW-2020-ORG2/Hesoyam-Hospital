// File:    ArticleController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class ArticleController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class ArticleController : IController<Article, long>
    {
        public ArticleService articleService;

        public ArticleController(ArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
            => articleService.GetArticleByAuthor(author);

        public IEnumerable<Article> GetAll()
            => articleService.GetAll();

        public Article GetByID(long id)
            => articleService.GetByID(id);

        public Article Create(Article entity)
            => articleService.Create(entity);

        public void Update(Article entity)
            => articleService.Update(entity);

        public void Delete(Article entity)
            => articleService.Delete(entity);

        

    }
}