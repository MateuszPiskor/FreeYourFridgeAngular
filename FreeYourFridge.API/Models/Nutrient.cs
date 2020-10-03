using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Models
{
    public class Nutrient
    {
        public string Title { get; set; }
        public float Amount { get; set; }
        public string Unit { get; set; }
        public float PercentOfDailyNeeds { get; set; }
    }
}
