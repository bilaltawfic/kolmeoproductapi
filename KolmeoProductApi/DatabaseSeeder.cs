using KolmeoProductApi.Models;
using KolmeoProductApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KolmeoProductApi
{
    /// <summary>
    /// Used to seed the database.
    /// </summary>
    public class DatabaseSeeder
    {
        /// <summary>
        /// Seed the database.
        /// </summary>
        /// <param name="serviceProvider">The service provider that contains the DbContext</param>
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new KolmeoProductDbContext(serviceProvider.GetRequiredService<DbContextOptions<KolmeoProductDbContext>>()))
            {
                // Look for any products
                if (context.Products.Any())
                {
                    // Data was already seeded
                    return;
                }

                context.Products.AddRange(
                    new Product()
                    {
                        Id = new Guid("2654d1c3-7b65-42ea-8687-50594495fb43"),
                        Name = "Yeezy 360",
                        Description = "A collectable designed by Kanye West.",
                        Price = 499,
                    },
                    new Product()
                    {
                        Id = new Guid("676173a4-a46a-4cf8-ae42-1083461a67e4"),
                        Name = "Pegasus 37",
                        Description = "The perfect all round sneaker.",
                        Price = 219.99m,
                    },
                    new Product()
                    {
                        Id = new Guid("49365717-fb73-4b2d-a6fa-e93c3d2e96c0"),
                        Name = "UltraBoost DNA",
                        Description = "An all rounder and an instant classic.",
                        Price = 240.20m,
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
