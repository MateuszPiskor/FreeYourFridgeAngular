using System.ComponentModel.DataAnnotations;
namespace FreeYourFridge.API.DTOs
{
    public class UserForLoginDto
    {
        public string Username{get;set;}
        public string Password{get;set;}
    }
}