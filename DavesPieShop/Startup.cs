using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DavesPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DavesPieShop
{
    public class Startup
    {
        // In order to access settings from appsettings.json, we need to create the appropriate property, and pass it into the Startup instance with constructor injection
        // First create the field
        public IConfiguration Configuration { get; }

        // Then overload the constructor, pass in IConfiguration, and assign it to the Configuration property
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // register services here through Dependency Injection
            // through DI we can acheive a a loose coupling architecture for our project
            // tight coupling requires hard interactions between classes, adding an interface helps a little
            // DI container handles creating instances of classes, it is the place where we register all of our dependencies
            // everyone knows about the DI container, and can ask it for what it needs
            // This method is where we register framework servives and all of our own services

            // We need to use the extension method AddDbContext with the type <AppDbContext> (which we defined in Models), along with options, UseSqlServer
            // We also need to pass in connection string to UseSqlServer.  The above property and constructor method gives us access to appsettings.json through Configuration property
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddControllersWithViews();

            // framework services are built in
            // our own services
            // registration options -
            // AddTransient get a new, clean instance
            // AddSingleton gets a single object, the same instance every time
            // AddScoped creates one instance per request, but uses it for other calls within same request (like a singleton per request - good for data access)


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add middleware here
            // this is the reuest pipeline, a number of components chained to one another
            // these components intercept and handle http requests, and create http response
            // each component (middleware) can alter the request/response and pass it to the next component
            
            // the order in which middleware is listed is important!

            if (env.IsDevelopment())
            {
                // this middleware enables use of exception pages in development, which provides us with useful information
                app.UseDeveloperExceptionPage();
            }

            // redirects HTTP to HTTPS
            app.UseHttpsRedirection();
            // this middleware enables ability for site to serve static files, default location is the wwwroot folder
            app.UseStaticFiles();
            // this middleware adds support for text only headers for status codes
            app.UseStatusCodePages();

            app.UseRouting();

            // this middleware enables routing the request to the correct endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
