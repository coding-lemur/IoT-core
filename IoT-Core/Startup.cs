﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IoT_Core.Models;
using IoT_Core.Middelware;
using Microsoft.AspNetCore.HttpOverrides;
using IoT_Core.Services;

namespace IoT_Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");

            services.AddDbContext<DataContext>(options => 
                options.UseMySql(
                    sqlConnectionString, 
                    b => b.MigrationsAssembly("IoT-Core")
                )
            );

            services.AddMvc();
            services.AddTransient<IWateringService, WateringService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // for reverse-proxy support
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsProduction())
            {
                app.UseSecretAuthentication();
            }

            app.UseMvc(routes =>
            {
                // default route
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Default}/{action=Get}/{id?}");
            });
            
            if (env.IsDevelopment())
            {
                // create database
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var sensorValueContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                    sensorValueContext.Database.EnsureCreated();
                }
            }
        }
    }
}
