using Feedbacks.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Feedbacks.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySql(GenerateConnectionString());
            }
        }

        private string GenerateConnectionString()
            => Environment.GetEnvironmentVariable("MyDbConnectionString");
    }
}
