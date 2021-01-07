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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySql(GenerateConnectionString());
            }
        }

        private string GenerateConnectionString()
            => Environment.GetEnvironmentVariable("MyDbConnectionString");

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
