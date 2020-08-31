using System.Collections;
using System.Collections.Generic;
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
            CreateMap<Recipes, RecipeForListDto>().ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(src=>src.Image));
            CreateMap<Recipes, RecipeForDetailDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Image));
        }
    }
}