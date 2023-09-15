using AutoMapper;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using DataLayer.Entity;
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
            CreateMap<CarDto, CarDomain>().ReverseMap();
            CreateMap<RentedCarDomain, RentedCarDto>()
                .ForMember(dest => dest.CarDto, opt => opt.MapFrom(src => src.CarDomain))
                .ForMember(dest => dest.UserDto, opt => opt.MapFrom(src => src.UserDomain));
            CreateMap<RentedCarDto, RentedCarDomain>()
                .ForMember(dest => dest.CarDomain, opt => opt.MapFrom(src => src.CarDto))
                .ForMember(dest => dest.UserDomain, opt => opt.MapFrom(src => src.UserDto));
            CreateMap<UserDto, UserDomain>().ReverseMap();
        }
    }
}
