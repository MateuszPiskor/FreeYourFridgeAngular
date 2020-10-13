using FreeYourFridge.API.Models;

namespace FreeYourFridge.API.DTOs
{
    public class UserForListDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public int DailyDemand { get; set; }
        public int DailyDemandToRealize { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Protein { get; set; }
        public string Description { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        // public int Id { get; set; }
        //public string PhotoUrl { get; set; }
    }
}