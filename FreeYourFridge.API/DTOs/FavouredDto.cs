using System;

namespace FreeYourFridge.API.DTOs
{
    public class FavouredDto
    {
        public int Score { get; set; }
        public int SpoonacularId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
    }
}