namespace FreeYourFridge.API.DTOs
{
    public class UserForUpdateDto
    {
        public int DailyDemand {get;set;}
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
    }
}