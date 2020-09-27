using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            CreateMap<User,UserForListDto>();
            CreateMap<UserDetails,UserForListDto>();
            CreateMap<UserForUpdateDto ,UserDetails>();
            CreateMap<UserForRegisterDto, User>();
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
            CreateMap<DailyMeal, DailyMealBasicDto>();

            CreateMap<DailyMealToAddDto, DailyMeal>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id));

            CreateMap<Models.DailyMeal, DTOs.DailyMealDetailedDto>();

            CreateMap<ExternalModels.Step, Models.AcceptStep>();
            CreateMap<ExternalModels.Analyzedinstruction, Models.AcceptAnalyzedinstruction>();
            CreateMap<ExternalModels.IncomingRecipe, Models.AcceptRecipe>();

            CreateMap<ExternalModels.IncomingRecipe, DTOs.DailyMealDetailedDto>()
                .ForMember(dest => dest.ReadyInMinute, opt => opt.MapFrom(src => src.readyInMinutes))
                .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src => src.analyzedInstructions));
                //.ForMember(d=>d.Nutritions,o=>o.MapFrom(src=>src.nutrition));

            CreateMap<ExternalModels.Nutrient, Models.AcceptNutrient>();
            CreateMap<ExternalModels.Caloricbreakdown, Models.AcceptCaloricbreakdown>();
            CreateMap<ExternalModels.Nutrition, Models.AcceptNutrition>()
                .ForMember(d=>d.nutrients,o=>o.MapFrom(src=>src.nutrients))
                .ForMember(d=>d.caloricBreakdown,o=>o.MapFrom(src=>src.caloricBreakdown));

            //CreateMap<ExternalModels.Nutrition, DailyMealDetailedDto>();
            //.ForMember(d => d.Nutritions, o => o.MapFrom(src => src.nutrients));



            //CreateMap<ExternalModels.Nutrition, DTOs.DailyMealDetailedDto>()
            //    .ForMember(dest => dest.Nutritions, 
            //        opt => opt.MapFrom(src => src.nutrients));
            //CreateMap<ExternalModels.Extendedingredient, DTOs.ExternalUsedIngredientDto>()
            //    .ForMember(dest => dest.amount,
            //        opt => opt.MapFrom(src => src.amount))
            //    .ForMember(dest => dest.name,
            //        opt => opt.MapFrom(src => src.name))
            //    .ForMember(dest => dest.original,
            //        opt => opt.MapFrom(src => src.original))
            //    .ForMember(dest => dest.unit,
            //        opt => opt.MapFrom(src => src.unit));

        }
    }
}