using Authentication.Model;
using Authentication.Util;
using Microsoft.EntityFrameworkCore;
using System;

namespace Authentication.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!IsPostgres())
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseMySql(GenerateConnectionString());
                }
            }
            else
            {
                //optionsBuilder.UseNpgsql(GeneratePostgresConnectionString());
            }
        }

        private bool IsPostgres()
        {
            return Environment.GetEnvironmentVariable("USES_POSTGRES") == "TRUE";
        }

        private string GenerateConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            if (Environment.GetEnvironmentVariable("MyDbConnectionString") == null)
                return "server=localhost;port=3306;database=mydb1;user=root;password=root";

            return "server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }

        private string GeneratePostgresConnectionString()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return "Server=" + server.Trim() + ";" + Environment.GetEnvironmentVariable("MyDbConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                    .ToTable("Users")
                    .HasDiscriminator<string>("ContentType")
                    .HasValue<User>("User")
                    .HasValue<Patient>("Patient")
                    .HasValue<SystemAdmin>("SystemAdmin")
                    .HasValue<Doctor>("Doctor");
        }
    }
}
