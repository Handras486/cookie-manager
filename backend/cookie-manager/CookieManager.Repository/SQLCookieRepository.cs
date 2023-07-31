using CookieManager.Data;
using CookieManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository
{
    public class SQLCookieRepository : ICookieRepository
    {
        private readonly CookieManagerDbContext dbContext;

        public SQLCookieRepository(CookieManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Cookie> CreateAsync(Cookie cookie)
        {
            await dbContext.Cookies.AddAsync(cookie);
            await dbContext.SaveChangesAsync();
            return cookie;
        }

        public async Task<Cookie?> DeleteAsync(Guid id)
        {
            var existingCookie = await dbContext.Cookies.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCookie == null)
                return null;

            dbContext.Cookies.Remove(existingCookie);
            await dbContext.SaveChangesAsync();

            return existingCookie;

        }

        public async Task<List<Cookie>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
        {
            var cookies = dbContext.Cookies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    cookies = cookies.Where(x => x.Name.Contains(filterQuery));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    cookies = isAscending ? cookies.OrderBy(x => x.Name) : cookies.OrderByDescending(x => x.Name);
            }

            var skipResults = (pageNumber - 1) * pageSize;


            return await cookies.Skip(skipResults).Take(pageSize).ToListAsync();
            // return await dbContext.Cookies.ToListAsync();
        }

        public async Task<Cookie?> GetAsync(Guid id)
        {
            return await dbContext.Cookies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cookie?> UpdateAsync(Guid id, Cookie cookie)
        {
            var existingCookie = await dbContext.Cookies.FirstOrDefaultAsync(x  => x.Id == id);

            if (existingCookie == null)
                return null;

            existingCookie.Name = cookie.Name;
            existingCookie.CookieImageUrl = cookie.CookieImageUrl;

            await dbContext.SaveChangesAsync();
            return existingCookie;
        }
    }
}
