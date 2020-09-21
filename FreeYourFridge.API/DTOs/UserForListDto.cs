namespace FreeYourFridge.API.DTOs
{
    public class UserForListDto
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string PhotoUrl { get; set; }
=======
        public string Username{get;set;}
        public string Email {get;set;}
        public string Gender {get;set;}
        public int Age {get;set;}
        public decimal Weight{get;set;}
        public decimal Height {get;set;}
        public int DailyDemand {get;set;}
>>>>>>> Merge/feature-user-with-feature-recpices
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
        public string Description{get;set;}
    }
}