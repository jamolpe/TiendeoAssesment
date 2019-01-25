﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServicesLibrary.Helpers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Mocker;
using ServicesLibrary.Services;
using TiendeoAPI.Models;

namespace TiendeoAPI
{
    public class Startup
    {
        private Settings _settings;
        private IConfigurationSection _configurationSection;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

          
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            this._configurationSection = Configuration.GetSection("AppSettings");
            this._settings = this._configurationSection.Get<Settings>();
            services.Configure<Settings>(this._configurationSection);
            if (this._settings.UseMockData)
            {
                services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TiendeoDB"));

            }
            else
            {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(this._settings.DataBaseConnection));
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ILocalService, LocalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<DataContext>();
                    DatabaseMocker databaseMocker = new DatabaseMocker(context);
                    databaseMocker.Seed();
                }
                
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
