﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Backend.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Backend.Repository.MySQLRepository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Hospital> Hospitals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MyDbConnectionString");
                */
                optionsBuilder.UseMySql("server = localhost; port = 3306; database = mydb; user = root; password = root");
            }
        }
    }
}
