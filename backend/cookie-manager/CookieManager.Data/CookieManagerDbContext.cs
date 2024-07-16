using CookieManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookieManager.Data
{
    public class CookieManagerDbContext : DbContext
    {
        public CookieManagerDbContext(DbContextOptions<CookieManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Cookie> Cookies { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data

            var cookies = new List<Cookie>()
            {
                new Cookie
                {
                    Id = Guid.Parse("af729dc0-c127-4193-a7dd-f3b97ce3d15d"),
                    Name = "Macaroon",
                    CookieImageUrl = "https://hips.hearstapps.com/hmg-prod/images/macaroon-vs-macaron-1676039139.jpeg",
                },
                new Cookie
                {
                    Id = Guid.Parse("db2c4249-09b2-4cea-ee93-08db8f741f17"),
                    Name = "Fortune cookie",
                    CookieImageUrl = "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg",
                },
                new Cookie
                {
                    Id = Guid.Parse("887cd1f7-3eff-4329-ee92-08db8f741f17"),
                    Name = "Chocolate chip",
                    CookieImageUrl = "https://www.shugarysweets.com/wp-content/uploads/2020/05/chocolate-chip-cookies-recipe.jpg",
                }
            };

            modelBuilder.Entity<Cookie>().HasData(cookies);
        }
    }
}