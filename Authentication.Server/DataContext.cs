
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthenticationServer.Models;


namespace AuthenticationServer
{
    public class DataContext : IdentityDbContext<MyUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //public DbSet<Batch> Batchs { get; set; }
        //public DbSet<Course> Courses { get; set; }




    }
}
