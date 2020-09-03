namespace FreeYourFridge.API.DTOs
{
    public class RecipeForDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Summary { get; set; }
        public int ReadyInMinutes { get; set; }
        public string Instructions { get; set; }
        public double SpoonacularScore { get; set; }
        public int Calories { get; set; }
        public string Carbs { get; set; }
        public string Fat { get; set; }
        public string Protein{ get; set; }
        public MissedingredientDto[] MissedingredientDto { get; set; }
        public UsedingredientDto[] UsedingredientDto { get; set; }
        //public bool Cheap { get; set; }
    }
}