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
            CreateMap<Car, CarDomain>().ReverseMap();
            CreateMap<RentedCar, RentedCarDomain>()
                .ForMember(dest => dest.CarDomain, opt => opt.MapFrom(src => src.Car))
                .ForMember(dest => dest.UserDomain, opt => opt.MapFrom(src => src.User));
            CreateMap<RentedCarDomain, RentedCar>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.CarDomain))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserDomain));
            CreateMap<User, UserDomain>().ReverseMap();
        }
    }
}
