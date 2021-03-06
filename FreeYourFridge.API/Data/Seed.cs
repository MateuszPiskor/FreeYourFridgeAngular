using System.Collections.Generic;
using System.Linq;
using FreeYourFridge.API.Models;
using Newtonsoft.Json;

namespace FreeYourFridge.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordhash, passwordSalt;
                    CreatePasswordHash("password", out passwordhash, out passwordSalt);

                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                }

                var userDetails = System.IO.File.ReadAllText("Data/UserDetailsSeedData.json");
                var usersDetailsToAdd = JsonConvert.DeserializeObject<List<UserDetails>>(userDetails);
                foreach (var userDetailsToAdd in usersDetailsToAdd)
                {
                    userDetailsToAdd.User = context.Users.Where(u => u.Id == userDetailsToAdd.UserId) as User;
                    context.UsersDetails.Add(userDetailsToAdd);
                }

                context.SaveChanges();
            }
        }
        public static void SeedIngredients(DataContext context)
        {
            if (!context.ListOfIngredients.Any())
            {
                var ingredientsData = System.IO.File.ReadAllText("Data/ingredient.json");
                var ingredients = JsonConvert.DeserializeObject<List<ListOfIngredients>>(ingredientsData);
                foreach (var ingredient in ingredients)
                {
                    context.ListOfIngredients.Add(ingredient);
                }
                context.SaveChanges();
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}