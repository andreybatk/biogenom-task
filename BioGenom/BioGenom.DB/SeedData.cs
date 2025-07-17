using BioGenom.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioGenom.DB
{
    public static class SeedData
    {
        public static async Task EnsureSeedDataAsync(ApplicationDbContext context)
        {
            if (await context.Reports.AnyAsync())
                return;

            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Description = "Description for product 1",
                ImageUrl = "https://example.com/image1.png"
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Description = "Description for product 2",
                ImageUrl = "https://example.com/image2.png"
            };

            var personalizedSet = new PersonalizedSet
            {
                Items = new List<PersonalizedItem>
            {
                new PersonalizedItem
                {
                    Product = product1,
                    AlternativesCount = 2
                },
                new PersonalizedItem
                {
                    Product = product2,
                    AlternativesCount = 1
                }
            }
            };

            var report = new Report
            {
                CreatedAt = DateTime.UtcNow,
                PersonalizedSet = personalizedSet,
                DailyIntakes = new List<DailyIntake>
            {
                new DailyIntake
                {
                    Id = Guid.NewGuid(),
                    Name = "Витамин C",
                    Source = "Пища",
                    Value = 42.39f,
                    Norm = 100f
                },
                new DailyIntake
                {
                    Id = Guid.NewGuid(),
                    Name = "Железо",
                    Source = "Пища",
                    Value = 18.0f,
                    Norm = 14.0f
                }
            },
                NewDailyIntakes = new List<NewDailyIntake>
            {
                new NewDailyIntake
                {
                    Id = Guid.NewGuid(),
                    Name = "Витамин C",
                    Source = "Пища + набор",
                    Value = 90.0f,
                    ValueFromSet = 50.0f,
                    ValueFromFood = 40.0f
                },
                new NewDailyIntake
                {
                    Id = Guid.NewGuid(),
                    Name = "Железо",
                    Source = "Пища + набор",
                    Value = 16.0f,
                    ValueFromSet = 4.0f,
                    ValueFromFood = 12.0f
                }
            }
            };

            context.Reports.Add(report);
            await context.SaveChangesAsync();
        }
    }
}
