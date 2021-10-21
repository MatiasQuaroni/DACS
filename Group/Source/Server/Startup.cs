using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.Application.Services.DataTransfer.MappingProfiles;
using Server.Persistence;
using Server.Application.Services;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RoadsDbContext>();
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Server", Version = "v1"}); });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
                mc.AddProfile(new ItineraryMappingProfile());
                mc.AddProfile(new LegMappingProfile());
                mc.AddProfile(new LocationMappingProfile());
                mc.AddProfile(new ShipmentMappingProfile());
                mc.AddProfile(new ShipmentStateMappingProfile());
                mc.AddProfile(new UserMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
            services.AddTransient<IShipmentsServices, ShipmentsServices>();        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}