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
        public DateTime Age {get;set;}
        public decimal Weight{get;set;}
        public decimal Height {get;set;}
    }
}