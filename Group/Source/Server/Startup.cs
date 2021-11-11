using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Server.Application.Services.DataTransfer.MappingProfiles;
using Server.Persistence;
using Server.Application.Services;
using Server.Persistence.UnitOfWork;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Server
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
            services.AddDbContext<RoadsDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IShipmentsServices, ShipmentsServices>();
            services.AddTransient<IUsersServices, UsersServices>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMappingProfile());
                mc.AddProfile(new ItineraryMappingProfile());
                mc.AddProfile(new LegMappingProfile());
                mc.AddProfile(new LocationMappingProfile());
                mc.AddProfile(new ShipmentMappingProfile());
                mc.AddProfile(new ShipmentStateMappingProfile());
                mc.AddProfile(new UserMappingProfile());
                mc.AddProfile(new ProfileInfoMappingProfile());
                mc.AddProfile(new UserStateMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Server", Version = "v1"}); });
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("./dacs2021g2-0d70fb764546.json"),
            });
        }

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