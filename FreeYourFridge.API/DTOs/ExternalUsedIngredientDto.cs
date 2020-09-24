using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class ExternalUsedIngredientDto
    {
        public float amount { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string unit { get; set; }
    }
}
