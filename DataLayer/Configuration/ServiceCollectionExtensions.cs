﻿//using FinalTest.DataLayer.DataContext;
//using FinalTest.DataLayer.Repository.Implementation;
//using FinalTest.DataLayer.Repository.Interface;
//using FinalTest.DataLayer.UoW;
using DataLayer.DataContext;
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

            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
            //services.AddScoped<IReviewRepository, ReviewRepository>();

            //services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();

            return services;
        }
    }
}
