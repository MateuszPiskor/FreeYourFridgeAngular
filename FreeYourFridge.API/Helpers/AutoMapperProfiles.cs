using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            CreateMap<ExternalModels.Properties, Models.AcceptProperties>();
            CreateMap<ExternalModels.Weightperserving, Models.AcceptWeightperserving>();
            CreateMap<ExternalModels.Caloricbreakdown, Models.AcceptCaloricbreakdown>();
            CreateMap<ExternalModels.Nutrition, Models.AcceptNutrition>()
                .ForMember(d=>d.nutrients,o=>o.MapFrom(src=>src.nutrients))
                .ForMember(d=>d.caloricBreakdown,o=>o.MapFrom(src=>src.caloricBreakdown))
                .ForMember(d => d.weightPerServing, o => o.MapFrom(src => src.weightPerServing))
                .ForMember(d => d.properties, o => o.MapFrom(src => src.properties));


            CreateMap<FavouredDto, Favoured>().ForMember(dest => dest.CreateTime,
                 opt => opt.MapFrom(src => DateTime.Now.ToShortDateString()));
            CreateMap<FavouredForRemoveDto, Favoured>();
        }
    }
}