using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public class DailyMealToArchive
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime DateTimeAddDeailyMeal { get; set; }
        [ForeignKey("DailyMeals")]
        public Guid LocalId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime TimeOfLastMeal { get; set; }
        public int Id { get; set; }
        public int Grams { get; set; }
        public string? UserRemarks { get; set; }
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int CreatedBy { get; set; }

    }
}
