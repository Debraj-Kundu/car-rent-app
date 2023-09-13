//using BuisnessLayer.ProductAppServices.Implementation;
//using BuisnessLayer.ProductAppServices.Interface;
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
            //services.AddScoped<ICartService, CartService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IReviewService, ReviewService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<ITopOrderService, TopOrderService>();
            //services.AddScoped<ICustomerService, CustomerService>();

            //DbContext and repository configurations of Data Layer
            services.RegisterDataContext(connectionString);

            return services;
        }
    }
}
