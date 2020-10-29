// File:    ArticleRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:38:19
// Purpose: Definition of Class ArticleRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class ArticleRepository : CSVRepository<Article, long>, IArticleRepository, IEagerCSVRepository<Article, long>
    {
        private const string ENTITY_NAME = "Article";
        private IDoctorRepository _doctorRepository;
        private IManagerRepository _managerRepository;
        private ISecretaryRepository _secretaryRepository;

        public ArticleRepository(ICSVStream<Article> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Article>())
        {
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Article Create(Article article)
        {
            article.Date = DateTime.Now;
            return base.Create(article);
        }

        private void BindArticlesWithAuthors(IEnumerable<Article> articles)
        {
            IEnumerable<Employee> doctors = _doctorRepository.GetAll();
            IEnumerable<Employee> managers = _managerRepository.GetAll();
            IEnumerable<Employee> secretaries = _secretaryRepository.GetAll();
            IEnumerable<Employee> employees = doctors.Concat(managers).Concat(secretaries);

            articles.ToList().ForEach(a => a.Author = GetEmployeeById(employees, a.Author));
        }

        private Employee GetEmployeeById(IEnumerable<Employee> employees, Employee author)
            => author == null ? null : employees.SingleOrDefault(e => e.GetId().Equals(author.GetId()));

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
            => GetAll().ToList().Where(article => IsAuthorIdsEqual(article.Author, author));

        private bool IsAuthorIdsEqual(Employee authorId, Employee selectedAuthor)
            => authorId == null ? false : selectedAuthor.GetId().Equals(authorId.GetId());

        public Article GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(article => article.GetId() == id);

        public IEnumerable<Article> GetAllEager()
        {
            var articles = GetAll();
            BindArticlesWithAuthors(articles);
            return articles;
        }

    }
}