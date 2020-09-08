using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class NutriotionForDetailDto
    {
        public int Calories { get; set; }
        public string Carbs { get; set; }
        public string Fat { get; set; }
        public string Protein { get; set; }
    }
}
