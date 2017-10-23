﻿
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace WebAPI
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(
            IServiceCollection services)
        {

            var secretKey = Configuration.GetSection("JwtSecurityToken:Key").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "http://logcorner.com",
                            ValidAudience = "http://logcorner.com",
                            IssuerSigningKey = signingKey
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Member",
            //        policy => policy.RequireClaim("MembershipId"));
            //});



           // services.AddDbContext<DbEntities>(options =>
           //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("DataAccessLayer")));

            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddTransient<ICourseServices, CourseServices>();          
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddMvc();
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("AnyGET", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .WithMethods("GET", "PUT", "POST", "DELETE")
                        .AllowAnyOrigin();
                });

                cfg.AddPolicy("AngularClient", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3276");
                });
            });
        }



        public virtual void SetUpDataBase(IServiceCollection services)
        {

            //services.AddDbContext<DbEntities>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("DataAccessLayer")));
        }

        public virtual void EnsureDatabaseCreated(DbEntities dbContext)
        {
           // dbContext.Database.Migrate();
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

