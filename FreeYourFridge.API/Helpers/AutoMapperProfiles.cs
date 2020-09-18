using AutoMapper;
using FreeYourFridge.API.DTOs;
using FreeYourFridge.API.DTOs.ToDoItemDto;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<RecipeToList, RecipesToListDto>();
            CreateMap<RecipeToDetail, RecipeToDetailDto>();
            CreateMap<Missedingredient, MissedingredientDto>();
            CreateMap<Usedingredient, UsedingredientDto>();
            CreateMap<Nutrition, NutriotionForDetailDto>();
            CreateMap<ToDoItemToAddDto, ToDoItem>();
            CreateMap<ToDoItem, ToDoItemToListDto>().ForMember(
                        dest => dest.SpoonacularId,
                        opt => opt.MapFrom(src => src.SpoonacularId));
        }
    }
}