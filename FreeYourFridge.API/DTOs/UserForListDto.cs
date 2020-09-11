namespace FreeYourFridge.API.DTOs
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string PhotoUrl { get; set; }
    }
}