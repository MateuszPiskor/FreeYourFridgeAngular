using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public class Fridge
    {
        [Key]
        public int Id{get;set;}
        
        [ForeignKey("User")]
        public int IdUser{get;set;}        
        public ICollection<Ingredient> ListIgredients{get;set;}
        public User user {get;set;}
    }
}