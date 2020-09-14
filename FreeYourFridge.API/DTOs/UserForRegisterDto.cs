using System.ComponentModel.DataAnnotations;

namespace FreeYourFridge.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username{get; set;}

        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage="You must specify password between 4 and 8 characters")]
        public string Password {get;set;}
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email{get;set;}

        [Required]
        public string Gender{get;set;}

        [Required]
        [Range(18,99)]
        public int Age{get;set;}

        [Required(ErrorMessage = "Weight is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be positive")]
        public decimal Weight{get;set;}

        [Required(ErrorMessage = "Height is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Height must be positive")]
        public decimal Height {get;set;}
    }
}