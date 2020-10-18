namespace FreeYourFridge.API.Models
{
    public class Photo
    {
        public int Id{get; set;}
        public string UrlOfPhoto {get;set;}
        public string Description {get;set;}
        public User User {get;set;}
        // public int UserId {get;set;}
    }
}