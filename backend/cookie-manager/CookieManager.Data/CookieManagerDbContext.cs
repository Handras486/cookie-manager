using CookieManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookieManager.Data
{
    public class CookieManagerDbContext : DbContext
    {
        public CookieManagerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<Cookie> Cookies { get; set; }

        
    }
}