namespace FreeYourFridge.API.DTOs.ToDoItemDto
{
    public class ToDoItemToAddDto
    {
        public long Id { get; set; }
        public int SpoonacularId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public bool IsOnShoppingList { get; set; }
    }
}