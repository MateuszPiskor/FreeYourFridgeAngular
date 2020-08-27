using AutoMapper;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
        }
    }
}