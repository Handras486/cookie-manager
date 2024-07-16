using CookieManager.Core.Entities;
using CookieManager.Data;
using CookieManager.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository
{
    public class SQLActivityRepository : IActivityRepository
    {
        private readonly CookieManagerDbContext dbContext;

        public SQLActivityRepository(CookieManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Activity> CreateAsync(Activity activity)
        {
            await dbContext.Activities.AddAsync(activity);
            await dbContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity?> DeleteAsync(Guid id)
        {
            var existingActivity = await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);

            if (existingActivity == null)
                return null;

            dbContext.Activities.Remove(existingActivity);
            await dbContext.SaveChangesAsync();

            return existingActivity;
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            var activites = dbContext.Activities.AsQueryable();

            return await activites.ToListAsync();
        }

        public async Task<Activity?> GetAsync(Guid id)
        {
            return await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Activity?> UpdateAsync(Guid id, Activity activity)
        {
            var existingActivity = await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == id);

            if (existingActivity == null)
                return null;

            await dbContext.SaveChangesAsync();
            return existingActivity;
        }
    }
}
