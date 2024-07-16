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

            Seed.SeedData(modelBuilder);
        }
    }
}