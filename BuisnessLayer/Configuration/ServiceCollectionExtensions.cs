using BuisnessLayer.CarAppService.Implementation;
using BuisnessLayer.CarAppService.Interface;
using DataLayer.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRentedCarService, RentedCarService>();

            //DbContext and repository configurations of Data Layer
            services.RegisterDataContext(connectionString);

            return services;
        }
    }
}
