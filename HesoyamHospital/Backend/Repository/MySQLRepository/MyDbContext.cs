using System;
using System.Collections.Generic;
using System.Text;
using Backend.Model.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.MySQLRepository
{
    class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
