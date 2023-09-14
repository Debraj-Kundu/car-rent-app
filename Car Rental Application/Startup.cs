using Newtonsoft.Json.Serialization;
using BuisnessLayer.Configuration;
using SharedLayer.Core.ExceptionManagement;
using AutoMapper;
using BuisnessLayer.Mapper;
using FinalTest.WebAPI.Mapper;

namespace Car_Rental_Application
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private MapperConfiguration MapperConfiguration { get; set; }

        private IExceptionManager exceptionManager;


        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new ApiMappingProfile());
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp => MapperConfiguration.CreateMapper());

            services.RegisterServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddMvc().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            SharedLayer.Core.Logging.ILogger logger = new SharedLayer.Core.Logging.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddScoped<SharedLayer.Core.Logging.ILogger, SharedLayer.Core.Logging.Logger>();
            services.AddScoped<IExceptionManager, ExceptionManager>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
