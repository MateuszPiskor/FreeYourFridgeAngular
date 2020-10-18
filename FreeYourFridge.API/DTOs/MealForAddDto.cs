using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FreeYourFridge.API.DTOs
{
    public class MealForAddDto
    {
        public int SpoonacularId { get; set; }
        public string Title { get; set; }
        public int Grams { get; set; }
    }
}