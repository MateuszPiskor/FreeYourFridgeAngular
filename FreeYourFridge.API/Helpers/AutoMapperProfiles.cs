using System;
using AutoMapper;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.DTOs.ShoppingListItemsDto;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>();
            CreateMap<UserDetails,UserForListDto>();
            CreateMap<UserForUpdateDto ,UserDetails>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserForListDto>();
            CreateMap<RecipeToList, Recipe>();
            CreateMap<RecipeToDetail, RecipeToDetailDto>();
            CreateMap<Missedingredient, MissedingredientDto>();
            CreateMap<Usedingredient, UsedingredientDto>();
            CreateMap<Nutrition, NutriotionForDetailDto>();
            CreateMap<ShoppingListItemToAddDto, ShoppingListItem>();
            CreateMap<ShoppingListItem, ShoppingListItemDto>().ForMember(
                        dest => dest.SpoonacularId,
                        opt => opt.MapFrom(src => src.SpoonacularId));
            CreateMap<FavouredDto, Favoured>().ForMember(dest => dest.CreateTime,
                 opt => opt.MapFrom(src => DateTime.Now.ToShortDateString()));
            CreateMap<FavouredForRemoveDto, Favoured>();
        }
    }
}