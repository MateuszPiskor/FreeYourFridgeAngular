using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    public class IngredientDto
    {
        public int id {get;set;}
        public string originalName{get;set;}
        public List<string> possibleUnits{get;set;}
        
    }
}