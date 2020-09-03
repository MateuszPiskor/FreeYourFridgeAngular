using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public DbSet<UserDetails> UsersDetails {get;set;}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
} 