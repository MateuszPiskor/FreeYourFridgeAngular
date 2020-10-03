using System.ComponentModel.DataAnnotations;

namespace FreeYourFridge.API.Models
{
    public class ListOfIngredients
    {
        [Key]
        public string originalName{get;set;}
        public int id{get;set;}
    }
}