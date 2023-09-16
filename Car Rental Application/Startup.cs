using Newtonsoft.Json.Serialization;
using BuisnessLayer.Configuration;
using SharedLayer.Core.ExceptionManagement;
using AutoMapper;
using BuisnessLayer.Mapper;
using FinalTest.WebAPI.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.DTO;
using WebAPI.Service;
using Microsoft.Extensions.FileProviders;

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

            services.AddScoped<IFileService, FileService>();

            var _jwtsetting = Configuration.GetSection("JWTSetting");
            services.Configure<JWTSetting>(_jwtsetting);

            var authkey = Configuration.GetValue<string>("JWTSetting:securitykey");

            services.AddAuthentication(item =>
            {
                item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(item =>
            {

                item.RequireHttpsMetadata = true;
                item.SaveToken = true;
                item.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

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
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Uploads")),
                RequestPath = "/Resources"
            });

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
