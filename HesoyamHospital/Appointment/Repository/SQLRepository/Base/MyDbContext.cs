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
            if (!isPostgres())
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseMySql(GenerateConnectionString());
                }
            }
            else 
            {
                optionsBuilder.UseNpgsql(GeneratePostgresConnectionString());
            }
        }

        private bool isPostgres()
        {
            return Environment.GetEnvironmentVariable("USES_POSTGRES") == "TRUE";
        }



        private string GenerateConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            // if (Environment.GetEnvironmentVariable("MyDbConnectionString") == null)
            //     return "server=localhost;port=3306;database=mydb1;user=root;password=root";

            return "server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }
        private string GeneratePostgresConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return "Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }
    }
}
