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
        public bool Cheap { get; set; }
    }
}