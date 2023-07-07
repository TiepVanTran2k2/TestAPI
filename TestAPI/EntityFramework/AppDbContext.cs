using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestAPI.Models;

namespace TestAPI.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ConnectSqlDotNetFramework")
        {
            
        }
        public DbSet<Staff> Staff { get; set;}
        public DbSet<StaffInTask> StaffInTask { get;set;}
        public DbSet<Task> Task { get; set;}
    }
}