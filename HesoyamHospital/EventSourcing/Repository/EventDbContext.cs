using System;
using Microsoft.EntityFrameworkCore;
using EventSourcing.Model.Appointments;
using EventSourcing.Model.Authentication;
using EventSourcing.Model.Feedback;
using EventSourcing.Model.Scheduling;

namespace EventSourcing.Repository
{
    public class EventDbContext : DbContext
    {
        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }
        public DbSet<BlockPatientEvent> BlockPatientEvents { get; set; }
        public DbSet<SelectedDoctorEvent> SelectedDoctorEvents { get; set; }
        public DbSet<RegistrationEvent> RegistrationEvents { get; set; }
        public DbSet<FeedbackCreatedEvent> FeedbackCreatedEvents { get; set; }
        public DbSet<SurveyAnsweredEvent> SurveyAnsweredEvents { get; set; }
        public DbSet<SchedulingStartedEvent> SchedulingStartedEvents { get; set; }
        public DbSet<SchedulingEndedEvent> SchedulingEndedEvents { get; set; }
        public DbSet<SchedulingStepChangedEvent> SchedulingStepChangedEvents { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEvent>().ToTable("AppointmentEvents");
            modelBuilder.Entity<BlockPatientEvent>().ToTable("BlockPatientEvents");
            modelBuilder.Entity<SelectedDoctorEvent>().ToTable("SelectedDoctorEvents");
            modelBuilder.Entity<RegistrationEvent>().ToTable("RegistrationEvents");
            modelBuilder.Entity<FeedbackCreatedEvent>().ToTable("FeedbackCreatedEvent");
            modelBuilder.Entity<SurveyAnsweredEvent>().ToTable("SurveyAnsweredEvent");
            modelBuilder.Entity<SchedulingStartedEvent>().ToTable("SchedulingStartedEvent");
            modelBuilder.Entity<SchedulingEndedEvent>().ToTable("SchedulingEndedEvent");
            modelBuilder.Entity<SchedulingStepChangedEvent>().ToTable("SchedulingStepChangedEvent");
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
