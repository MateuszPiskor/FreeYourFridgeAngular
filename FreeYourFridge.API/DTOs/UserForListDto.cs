using System;
using System.Collections.Generic;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.DTOs
{
    public class UserForListDto
    {
        public int Id {get;set;}
        public string Username{get;set;}
        public string Gender {get;set;}
        public int Age {get;set;}
        public decimal Weight{get;set;}
        public decimal Height {get;set;}
        public int DailyDemand {get;set;}
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
        public string Description{get;set;}
    }
}