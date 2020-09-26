using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace FreeYourFridge.API.Models
{
    public class Favoured
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int Score { get; set; }
        public int SpoonacularId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string CreateTime { get; set; }
    }
}