using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using CookieManager.Data;
using CookieManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<List<Cookie>> GetAllAsync(CookieQueryParameters queryParameters)
        {
            var cookies = dbContext.Cookies.AsQueryable();


            if (queryParameters.filterOn.Equals("Name"))
                cookies = cookies.Where(x => x.Name.Contains(queryParameters.filterQuery));


            if (queryParameters.sortBy.Equals("Name"))
                cookies = queryParameters.isAscending ? cookies.OrderBy(x => x.Name) : cookies.OrderByDescending(x => x.Name);


            return await cookies.OrderBy(x => x.Name).Skip(queryParameters.GetSkipResults()).Take(queryParameters.pageSize).ToListAsync();
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

            if (cookie.Name != null)
                existingCookie.Name = cookie.Name;

            if (cookie.CookieImageUrl != null)
                existingCookie.CookieImageUrl = cookie.CookieImageUrl;

            await dbContext.SaveChangesAsync();
            return existingCookie;
        }
    }
}
