using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using MamaJennsPizza.Models;

namespace MamaJennsPizza.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }
            if (!context.Pizzas.Any())
            {
                context.Pizzas.AddRange(
                    new Pizza()
                    {
                        Name = "The Italian Stallion",
                        Price = 13.99m,
                        Toppings = "salami, sausage, olives and pepperoni",
                        User= mike
                    },
                    new Pizza()
                    {
                        Name = "The Garden Party",
                        Price = 11.99m,
                        Toppings = "spinach, mushrooms, tomato, bell peppers",
                        User = mike
                    },
                    new Pizza()
                    {
                        Name = "The Funky Chicken",
                        Price = 13.99m,
                        Toppings = "chicken, white sauce, jalapenos, onions",
                        User = stephen
                    },
                    new Pizza()
                    {
                        Name = "Mama Jenn's Special",
                        Price = 18.99m,
                        Toppings = "marinated artichokes, Italian sausage, fresh mozzarella, fresh basil",
                        User = stephen
                    }

                    );
                context.SaveChanges();
            }

        }

    }
}
