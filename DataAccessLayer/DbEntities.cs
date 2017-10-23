using Authentication.Server;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;

namespace DataAccessLayer

{

    public class DbEntities : DbContext
    {
        public DbEntities() 
        {
        }
        public DbEntities(DbContextOptions<DbEntities> dbco) :
        base(dbco)
    {

        }
        //public DbEntities(DbContextOptions opts) : base(opts)

        //{
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batchs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json")
          .Build();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(builder);
        }

    }







}
