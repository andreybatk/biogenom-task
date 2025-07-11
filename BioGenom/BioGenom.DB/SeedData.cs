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

            var report = new Report
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
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
                    ValueFromFood = 40.0f,
                },
                new NewDailyIntake
                {
                    Id = Guid.NewGuid(),
                    Name = "Железо",
                    Source = "Пища + набор",
                    Value = 16.0f,
                    ValueFromSet = 4.0f,
                    ValueFromFood = 12.0f,
                }
            }
            };

            context.Reports.Add(report);
            await context.SaveChangesAsync();
        }
    }
}
