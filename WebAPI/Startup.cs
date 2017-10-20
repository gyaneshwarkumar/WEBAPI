
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

namespace WebAPI
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment _env;

        public void ConfigureServices(
            IServiceCollection services)
        {
         //   DataAccessLayer.UnitOfWork.UnitOfWork
             //services.AddTransient(ICourseServices, CourseServices);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options => {
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,

            //                ValidIssuer = "Fiver.Security.Bearer",
            //                ValidAudience = "Fiver.Security.Bearer",
            //                IssuerSigningKey = JwtSecurityKey.Create("fiver-secret-key")
            //            };

            //            options.Events = new JwtBearerEvents
            //            {
            //                OnAuthenticationFailed = context =>
            //                {
            //                    Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
            //                    return Task.CompletedTask;
            //                },
            //                OnTokenValidated = context =>
            //                {
            //                    Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
            //                    return Task.CompletedTask;
            //                }
            //            };
            //        });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Member",
            //        policy => policy.RequireClaim("MembershipId"));
            //});
           services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<ICourseServices, CourseServices>();
            
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            // services.AddSingleton(typeof(IDataAccess<Course, int>), typeof(DataAccessRepository));
            services.AddMvc();
        }



        public virtual void SetUpDataBase(IServiceCollection services)
        {

            //services.AddDbContext<DbEntities>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("SecurityConnection"), sqlOptions => sqlOptions.MigrationsAssembly("DataAccessLayer")));
        }

        public virtual void EnsureDatabaseCreated(DbEntities dbContext)
        {
            // run Migrations
            dbContext.Database.Migrate();
        }

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
