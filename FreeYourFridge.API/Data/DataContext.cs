using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<UserDetails> UsersDetails {get;set;}
        public DbSet<Meal> Meals { get; set; }
        public DbSet<DailyMeal> DailyMeals { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ListOfIngredients> ListOfIngredients { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
} 