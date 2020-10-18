using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Models
{
    public class Nutrition2
    {
        public ICollection<Nutrient> nutrients { get; set; } /**/
        //public ICollection<Ingredient> ingredients { get; set; }
        //public Caloricbreakdown caloricBreakdown { get; set; }
        //public Weightperserving weightPerServing { get; set; }
    }
}
