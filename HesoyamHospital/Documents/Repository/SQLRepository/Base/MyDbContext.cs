using Documents.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Documents.Repository.SQLRepository.Base
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicalTherapy> Therapies { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }

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
            modelBuilder.Entity<DiseaseMedicine>().HasKey(dm => new { dm.DiseaseId, dm.MedicineId });
        }
    }
}
