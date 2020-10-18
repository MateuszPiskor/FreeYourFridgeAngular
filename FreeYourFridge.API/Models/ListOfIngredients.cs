using System.ComponentModel.DataAnnotations;

namespace FreeYourFridge.API.Models
{
    public class ListOfIngredients
    {
        [Key]
        public int id{get;set;}
        public string originalName{get;set;}
    }
}