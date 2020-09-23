using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeYourFridge.API.Models
{
    public class Fridge
    {
        [Key]
        public int Id{get;set;}
        public int UserId{get;set;}
        public User user {get;set;}
        public virtual ICollection<Ingredient> ListIgredients{get;set;}
    }
}