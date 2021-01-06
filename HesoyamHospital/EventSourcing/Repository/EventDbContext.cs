using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EventSourcing.Model;
using EventSourcing.Model.Appointments;

namespace EventSourcing.Repository
{
    public class EventDbContext : DbContext
    {
        public DbSet<AppointmentEvent> AppointmentEvents { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEvent>().ToTable("AppointmentEvents");
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
