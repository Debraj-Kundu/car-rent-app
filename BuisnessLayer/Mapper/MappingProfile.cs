using AutoMapper;
using BuisnessLayer.Domain;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("MappingProfile")
        {
            //CreateMap<Order, OrderDomain>().ReverseMap();
            CreateMap<Car, CarDomain>().ReverseMap();
            //CreateMap<Customer, CustomerDomain>().ReverseMap();
        }
    }
}
