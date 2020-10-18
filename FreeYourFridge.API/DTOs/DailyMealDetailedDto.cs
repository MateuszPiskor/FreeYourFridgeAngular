using System.Collections.Generic;
using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.DTOs
{
    public class DailyMealDetailedDto : DailyMealBasicDto
    {
        public int ReadyInMinute { get; set; }
        public AcceptNutrition Nutrition { get; set; }
        public ICollection<AcceptAnalyzedinstruction> Instructions { get; set; }
    }
}
