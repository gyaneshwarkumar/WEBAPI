//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Authentication.Server
//{
//    public class DataContext
//    {
//    }
//}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Token.WebApiCore.Server.Models;


namespace Authentication.Server
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
