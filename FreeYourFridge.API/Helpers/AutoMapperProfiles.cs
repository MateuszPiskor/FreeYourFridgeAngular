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
            CreateMap<Missedingredient, MissedingredientDto>();
            CreateMap<Usedingredient, UsedingredientDto>();
            CreateMap<Recipes, RecipeForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.UsedingredientDto, opt => opt.MapFrom(src => src.UsedIngredients))
                .ForMember(dest => dest.MissedingredientDto, opt => opt.MapFrom(src => src.MissedIngredients));
        }
    }
}