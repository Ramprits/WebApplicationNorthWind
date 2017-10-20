﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApplicationNorthWind.Northwind;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebApplicationNorthWind.SampleDb.SampleEntities;

namespace WebApplicationNorthWind
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("NorthwindConnectionConnection"));
            });
            services.AddDbContext<SampledbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SampleDbContext"));
            });

            services.AddMvc(opt =>
            {
                opt.Filters.Add(new RequireHttpsAttribute());
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling =
                  ReferenceLoopHandling.Ignore;
            });
            services.AddCors(config =>
            {
                config.AddPolicy("MyApplication", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod().AllowAnyMethod();
                });

                config.AddPolicy("AnyGET", builder =>
                {
                    builder.AllowAnyHeader()
                       .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            services.AddAutoMapper();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepositry, ProductRepositry>();
            services.AddScoped<IFruitRepository, FruitRepository>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logerFactory)
        {
            logerFactory.AddConsole();
            var loggerForTesting = logerFactory.CreateLogger("TestingCategory");
            loggerForTesting.LogInformation("Testing logger");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors((corsPolicyBuilder) =>
            {
                corsPolicyBuilder.AllowAnyOrigin();
                corsPolicyBuilder.AllowAnyMethod();
                corsPolicyBuilder.AllowAnyHeader();
            });

            app.UseMvc();
        }
    }
}
