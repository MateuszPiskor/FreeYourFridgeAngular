namespace FreeYourFridge.API.Models
{
    public class Instruction
    {
        public string name { get; set; }
        public Instructionstep[] steps { get; set; }
    }
}