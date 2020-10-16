using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public enum ActivityLevel
    {
        Low, Medium, High
    }
    public class UserDetails
    {
        public int Id { get; set; }
        public int DailyDemand { get; set; }
        public int DailyDemandToRealize { get; set; }
        private int carbohydrates;
        public int Carbohydrates
        {
            get => carbohydrates;
            set => carbohydrates = (int)((DailyDemand * 0.5) / 10);
        }

        private int fats;
        public int Fats
        {
            get => fats;
            set => fats = (int)((DailyDemand * 0.25) / 10);
        }

        private int protein;
        public int Protein
        {
            get => protein;
            set => protein = (int)((DailyDemand * 0.25) / 10);
        }
        public string Description { get; set; }
        public User User { get; set; }
        public ActivityLevel ActivityLevel { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}