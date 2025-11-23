using AutoMapper;
using Lab11.Application.DTOs;
using Lab11.Domain.Entities;


namespace Lab11.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}