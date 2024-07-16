using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Repository.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync();

        Task<Activity?> GetAsync(Guid id);

        Task<Activity> CreateAsync(Activity activity);

        Task<Activity?> UpdateAsync(Guid id, Activity activity);

        Task<Activity?> DeleteAsync(Guid id);
    }
}
