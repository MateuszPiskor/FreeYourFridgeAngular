using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public enum ActivityLevel
    {
        Low,Medium,High
    }
    public class UserDetails
    {
        public int Id{get;set;}
        public int DailyDemand {get;set;}
        public int Carbohydrates {get; set;}
        public int Fats{get;set;}
        public int Protein{get;set;}
        public string Description{get;set;}
        public User User{get;set;}
        
        [ForeignKey("User")]
        public int UserId{get;set;}

    }
}