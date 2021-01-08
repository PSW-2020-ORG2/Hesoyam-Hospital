using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventSourcing.Model;
using EventSourcing.Model.Appointments;
using EventSourcing.Model.Authentication;
using EventSourcing.Model.Feedback;

namespace EventSourcing.Repository
{
    public class EventDbContext : DbContext
    {
        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }
        public DbSet<BlockPatientEvent> BlockPatientEvents { get; set; }
        public DbSet<SelectedDoctorEvent> SelectedDoctorEvents { get; set; }
        public DbSet<FeedbackCreatedEvent> FeedbackCreatedEvents { get; set; }

        public DbSet<SurveyAnsweredEvent> SurveyAnsweredEvents { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEvent>().ToTable("AppointmentEvents");
            modelBuilder.Entity<BlockPatientEvent>().ToTable("BlockPatientEvents");
            modelBuilder.Entity<SelectedDoctorEvent>().ToTable("SelectedDoctorEvents");
            modelBuilder.Entity<FeedbackCreatedEvent>().ToTable("FeedbackCreatedEvent");
            modelBuilder.Entity<SurveyAnsweredEvent>().ToTable("SurveyAnsweredEvent");
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
