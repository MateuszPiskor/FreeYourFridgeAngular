namespace FreeYourFridge.API.Models
{
    public class UserDetails
    {
        public int DailyDemand {get;set;}
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
        public string Description{get;set;}
        public User Id{get;set;}

    }
}