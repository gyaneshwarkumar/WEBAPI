using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
             builder.UseSqlServer("Server=DESKTOP-TNSM1B0\\MSSQLSERVER2012;Database=ERP21;Trusted_Connection=True;");
         // builder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);

            // builder.UseSqlServer(@"Server=.\;Database=EFTutorial;Trusted_Connection=True;").SuppressAmbientTransactionWarning();
            //base.OnConfiguring(optionsBuilder);

          base.OnConfiguring(builder);
        }
    }







}
