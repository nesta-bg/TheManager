using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TheManager
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //1. Terminal Middleware (it doesn't call the next middleware in the pipeline)
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from First Middleware");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from Second Middleware");
            //});

            //2. When we want to call the second middleware
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from First Middleware");
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from Second Middleware");
            //});

            //3. Run the Project in Debug Mode. Look at Output.Debug
            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outhgoing Response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outhgoing Response");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and Response produced");
                logger.LogInformation("MW3: Request handled and Response produced");
            });
        }
    }
}
