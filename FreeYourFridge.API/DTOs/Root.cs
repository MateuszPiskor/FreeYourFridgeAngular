using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FreeYourFridge.API.DTOs
{
    public class Root
    {
        [JsonProperty("results")]
        public RecipeToList[] Results { get; set; }
    }
}
