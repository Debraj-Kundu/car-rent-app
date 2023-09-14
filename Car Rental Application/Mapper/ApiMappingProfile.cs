using AutoMapper;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.Mapper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile() : base("ApiMappingProfile")
        {
            //CreateMap<OrderDto, OrderDomain>().ReverseMap();
            CreateMap<CarDto, CarDomain>().ReverseMap();
            //CreateMap<CustomerDto, CustomerDomain>().ReverseMap();
        }
    }
}
