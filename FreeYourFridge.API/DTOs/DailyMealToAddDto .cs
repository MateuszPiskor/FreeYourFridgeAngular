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
        public string? UserRemarks { get; set; }

    }
}
