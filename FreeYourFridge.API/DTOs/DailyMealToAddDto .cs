using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class DailyMealToAddDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Grams { get; set; }
        public string? UserRemarks { get; set; }

    }
}
