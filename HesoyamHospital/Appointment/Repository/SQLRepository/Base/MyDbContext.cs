using Appointments.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Appointments.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }

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
