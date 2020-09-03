namespace FreeYourFridge.API.Models
{
    public class Usedingredient
    {
        public int id;
        public float amount { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string unit { get; set; }
    }

}