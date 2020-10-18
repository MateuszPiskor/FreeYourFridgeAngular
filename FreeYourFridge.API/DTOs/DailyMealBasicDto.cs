using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class DailyMealBasicDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

        public DateTime TimeOfLastMeal { get; set; }
        public int Grams { get; set; }
        
    }
}
