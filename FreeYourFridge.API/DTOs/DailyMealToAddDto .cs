using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FreeYourFridge.API.DTOs
{
    [BindRequired]
    public class DailyMealToAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Grams { get; set; }
        public int Calories { get; set; }
#nullable enable
        public string? UserRemarks { get; set; }
#nullable disable
    }
}
