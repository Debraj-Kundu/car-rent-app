﻿using DataLayer.DataContext;
using DataLayer.Repository.Implementation;
using DataLayer.Repository.Interface;
using DataLayer.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarDomainDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Scoped);

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRentedCarRepository, RentedCarRepository>();

            services.AddScoped<ICarUnitOfWork, CarUnitOfWork>();

            return services;
        }
    }
}
