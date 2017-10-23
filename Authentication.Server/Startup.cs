using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using Token.WebApiCore.Server.Models;

namespace Authentication.Server
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add framework services.
            services.AddMvc();
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
            services.AddIdentity<MyUser, MyRole>(cfg =>
            {
                // if we are accessing the /api and an unauthorized request is made
                // do not redirect to the login page, but simply return "Unauthorized"
                //cfg.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
                //{
                //    OnRedirectToLogin = ctx =>
                //    {
                //        if (ctx.Request.Path.StartsWithSegments("/api"))
                //            ctx.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;

                //        return Task.FromResult(0);
                //    }
                //};
            }).AddEntityFrameworkStores<DataContext>();
          //  .AddDefaultTokenProviders();

            //   services.AddTransient<ProductRepository, ProductRepository>();

            services.AddCors(cfg =>
            {
                cfg.AddPolicy("AnyGET", bldr =>
                {
                    bldr.AllowAnyHeader()
                        .WithMethods("GET")
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
            services.AddDbContext<DataContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("Authentication.Server")));
        }

        public virtual void EnsureDatabaseCreated(DataContext dbContext)
        {
            // run Migrations
            //  dbContext.Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //app.UseIdentity();

            //app.UseJwtBearerAuthentication(new JwtBearerOptions()
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
            //        ValidAudience = Configuration["JwtSecurityToken:Audience"],
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"])),
            //        ValidateLifetime = true
            //    }
            //});

            //app.UseMvc();
            app.UseMvc(routes =>
            {
            });

            // within your Configure method:
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
              .CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<DataContext>();
                EnsureDatabaseCreated(dbContext);
            }
        }
    }
}


//    public class Startup
//    {

//        public IConfigurationRoot Configuration { get; }
//        private IHostingEnvironment _env;

//        public Startup(IHostingEnvironment env)
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(env.ContentRootPath)
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
//                .AddEnvironmentVariables();
//            Configuration = builder.Build();
//        }

//        public void ConfigureServices(
//            IServiceCollection services)
//        {

//            var secretKey = Configuration.GetSection("JwtSecurityToken:Key").Value;
//            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                    .AddJwtBearer(options => {
//                        options.TokenValidationParameters = new TokenValidationParameters
//                        {
//                            ValidateIssuer = true,
//                            ValidateAudience = true,
//                            ValidateLifetime = true,
//                            ValidateIssuerSigningKey = true,

//                            ValidIssuer = "http://logcorner.com",
//                            ValidAudience = "http://logcorner.com",
//                            IssuerSigningKey = signingKey
//                        };

//                        options.Events = new JwtBearerEvents
//                        {
//                            OnAuthenticationFailed = context =>
//                            {
//                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
//                                return Task.CompletedTask;
//                            },
//                            OnTokenValidated = context =>
//                            {
//                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
//                                return Task.CompletedTask;
//                            }
//                        };
//                    });

//            //services.AddAuthorization(options =>
//            //{
//            //    options.AddPolicy("Member",
//            //        policy => policy.RequireClaim("MembershipId"));
//            //});



//            services.AddDbContext<DataContext>(options =>
//           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("Authentication.Server")));

//            //services.AddTransient<IUnitOfWork, UnitOfWork>();
//            //services.AddTransient<ICourseServices, CourseServices>();
//            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            //services.AddAutoMapper();
//            services.AddMvc();
//        }



//        public virtual void SetUpDataBase(IServiceCollection services)
//        {

//            services.AddDbContext<DataContext>(options =>
//  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlOptions => sqlOptions.MigrationsAssembly("Authentication.Server")));
//        }

//        public virtual void EnsureDatabaseCreated(DataContext dbContext)
//        {
//           // dbContext.Database.Migrate();
//        }

//        public void Configure(
//            IApplicationBuilder app,
//            IHostingEnvironment env)
//        {
//            app.UseDeveloperExceptionPage();
//            app.UseStaticFiles();
//            app.UseAuthentication();
//            app.UseMvcWithDefaultRoute();
//            loggerFactory.AddDebug();
//        }
//    }
//}

