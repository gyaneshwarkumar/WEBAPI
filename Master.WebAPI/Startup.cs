
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
using FluentValidation.AspNetCore;
using WebAPI.Filters;
using Microsoft.Extensions.Logging;
using Serilog;

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

            Log.Logger = new LoggerConfiguration()
      .WriteTo.File(@"E:\log.txt")
      .CreateLogger();


        }

        public void ConfigureServices(
            IServiceCollection services)
        {

            SetUpDataBase(services);
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

                            ValidIssuer = Configuration.GetSection("JwtSecurityToken:Issuer").Value,// "http://logcorner.com",
                            ValidAudience = Configuration.GetSection("JwtSecurityToken:Audience").Value,
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

            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<ICourseServices, CourseServices>();
            services.AddTransient<IBatchServices, BatchServices>();

            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper();
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
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
                        .WithOrigins("http://localhost:35344");
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
            IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}

