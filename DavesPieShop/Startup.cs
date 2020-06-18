using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DavesPieShop
{
    public class Startup
    {
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

            // framework services
            services.AddControllersWithViews();

            // our own services
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
            // this middleware enables ability for site to serve static files
            app.UseStaticFiles();
            // this middleware adds support for text only headers for status codes
            app.UseStatusCodePages();

            app.UseRouting();

            // this middleware enables routing the request to the correct endpoint
            app.UseEndpoints(endpoints =>
            {
                // this has been modified to handle routing in a more MVC way, instead of routing everything to "Hello World"
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{actions=Index}/{id?}");
            });
        }
    }
}
