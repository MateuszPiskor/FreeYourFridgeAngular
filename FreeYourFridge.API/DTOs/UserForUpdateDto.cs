using System;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.DTOs
{
    [Serializable]    
    public class UserForUpdateDto
    {
        public int DailyDemand {get;set;}
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
        public string Description{get;set;}
        public ActivityLevel ActivityLevel { get; set; }
    }
}