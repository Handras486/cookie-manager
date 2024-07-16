using CookieManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Data
{
    public class Seed
    {
        public static void SeedData(ModelBuilder modelBuilder) 
        {
            var cookies = new List<Cookie>()
            {
                new Cookie
                {
                    Id = Guid.NewGuid(),
                    Name = "Macaroon",
                    CookieImageUrl = "https://hips.hearstapps.com/hmg-prod/images/macaroon-vs-macaron-1676039139.jpeg",
                },
                new Cookie
                {
                    Id = Guid.NewGuid(),
                    Name = "Fortune cookie",
                    CookieImageUrl = "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg",
                },
                new Cookie
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate chip",
                    CookieImageUrl = "https://www.shugarysweets.com/wp-content/uploads/2020/05/chocolate-chip-cookies-recipe.jpg",
                }
            };

            var activities = new List<Activity>
            {
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Past Activity 1",
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Past Activity 2",
                    Date = DateTime.UtcNow.AddMonths(-1),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 1",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 2",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 3",
                    Date = DateTime.UtcNow.AddMonths(3),
                    Description = "Activity 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Another pub",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 4",
                    Date = DateTime.UtcNow.AddMonths(4),
                    Description = "Activity 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Yet another pub",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 5",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description = "Activity 5 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Just another pub",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 6",
                    Date = DateTime.UtcNow.AddMonths(6),
                    Description = "Activity 6 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "Roundhouse Camden",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 7",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description = "Activity 2 months ago",
                    Category = "travel",
                    City = "London",
                    Venue = "Somewhere on the Thames",
                },
                new Activity
                {
                    Id = Guid.NewGuid(),
                    Title = "Future Activity 8",
                    Date = DateTime.UtcNow.AddMonths(8),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "London",
                    Venue = "Cinema",
                }
            };

            modelBuilder.Entity<Cookie>().HasData(cookies);
            modelBuilder.Entity<Activity>().HasData(activities);
        }
    }
}
