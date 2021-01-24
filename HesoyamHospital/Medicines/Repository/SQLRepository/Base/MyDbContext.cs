using Medicines.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Medicines.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Therapy> Therapies { get; set; }

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

            return "server=" + server.Trim() + ";" + "port=3306;database=mydb1;user=root;password=root";
        }
        private string GeneratePostgresConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return "Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiseaseMedicine>().HasKey(dm => new { dm.DiseaseId, dm.MedicineId });
        }
    }
}
