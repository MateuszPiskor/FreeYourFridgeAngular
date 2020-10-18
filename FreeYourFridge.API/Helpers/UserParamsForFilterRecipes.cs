using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Helpers
{
    public class UserParamsForFilterRecipes
    {
        public string DietType { get; set; }
        public string CuisineType { get; set; }
        public string MealType { get; set; }
        public override string ToString()
        {
           string userParams= "";
            if (this.DietType != "undefined")
            {
                userParams += "&diet=" +this.DietType;
            }
            if (this.CuisineType != "undefined")
            {
                userParams +="&cuisine="+this.CuisineType;
            }
            if (this.MealType != "undefined")
            {
                userParams += "&type=" + this.MealType;
            }
            return userParams;
        }
    }
    
}