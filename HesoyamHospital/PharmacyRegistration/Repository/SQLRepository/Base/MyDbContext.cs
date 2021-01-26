using Microsoft.EntityFrameworkCore;
using PharmacyRegistration.Model;
using System;
using System.IO;

namespace PharmacyRegistration.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<RegisteredPharmacy> RegisteredPharmacies { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisteredPharmacy>().OwnsOne(rp => rp.ApiKey);
            modelBuilder.Entity<RegisteredPharmacy>().OwnsOne(rp => rp.Endpoint);
        }

        private string GenerateConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return "server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }
        private string GeneratePostgresConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return "Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }
    }
}
