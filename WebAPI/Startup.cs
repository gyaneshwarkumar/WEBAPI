
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using IBusinessServices;
using BusinessServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System.IO;

namespace WebAPI
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
       // private IHostingEnvironment _env;

        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        public void ConfigureServices(
            IServiceCollection services)
        {


           // services.AddDbContext<DbEntities>(options =>
           //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("DataAccessLayer")));

            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<ICourseServices, CourseServices>();          
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddMvc();
        }



        //public virtual void SetUpDataBase(IServiceCollection services)
        //{

        //    //services.AddDbContext<DbEntities>(options =>
        //    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("DataAccessLayer")));
        //}

        //public virtual void EnsureDatabaseCreated(DbEntities dbContext)
        //{
        //    // run Migrations
        //    dbContext.Database.Migrate();
        //}

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
