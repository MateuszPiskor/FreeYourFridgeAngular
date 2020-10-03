using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeYourFridge.API.DTOs
{
    public class FavouredForRemoveDto
    {
        public int Score { get; set; }
        public int SpoonacularId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string CreateTime { get; set; }

    }
}
