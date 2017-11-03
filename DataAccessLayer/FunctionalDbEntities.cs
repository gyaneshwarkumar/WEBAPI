using System;
using Authentication.Server;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace DataAccessLayer
{
    public class FunctionalDbEntities : DbContext
    {
        public FunctionalDbEntities()
        {

        }
        public FunctionalDbEntities(DbContextOptions<FunctionalDbEntities> dbco) :
        base(dbco)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .Build();
            builder.UseSqlServer("Server=DESKTOP-TNSM1B0\\MSSQLSERVER2012;Database=Functional;Trusted_Connection=True;");
            base.OnConfiguring(builder);
        }
    }
}
