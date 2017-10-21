using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Token.WebApiCore.Server.Models;


namespace Token.WebApiCore.Server
{
    public class SecurityContext : IdentityDbContext<MyUser>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        //public DbSet<Batch> Batchs { get; set; }
        //public DbSet<Course> Courses { get; set; }


        

    }
}