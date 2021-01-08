using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventSourcing.Model;
using EventSourcing.Model.Appointments;
using EventSourcing.Model.Authentication;

namespace EventSourcing.Repository
{
    public class EventDbContext : DbContext
    {
        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }
        public DbSet<BlockPatientEvent> BlockPatientEvents { get; set; }
        public DbSet<SelectedDoctorEvent> SelectedDoctorEvents { get; set; }
        public DbSet<RegistrationEvent> RegistrationEvents { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEvent>().ToTable("AppointmentEvents");
            modelBuilder.Entity<BlockPatientEvent>().ToTable("BlockPatientEvents");
            modelBuilder.Entity<SelectedDoctorEvent>().ToTable("SelectedDoctorEvents");
            modelBuilder.Entity<RegistrationEvent>().ToTable("RegistrationEvents");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseMySql(Environment.GetEnvironmentVariable("MyDbConnectionString"));
            }
                
        }
    }
}
