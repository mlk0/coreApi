using System;
using AutoMapper;
using hotels.api.Models;

namespace hotels.api.Mappers
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile(){

            CreateMap<UserData, UserResponse>();
            CreateMap<OrderData, OrderResponse>();

        }
    }
}
