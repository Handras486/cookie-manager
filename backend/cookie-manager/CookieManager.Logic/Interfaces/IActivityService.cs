using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieManager.Service.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAllActivitiesAsync();

        Task<Activity?> GetActivityAsync(Guid id);

        Task<Activity> CreateActivityAsync(Activity activity);

        Task<Activity?> UpdateActivityAsync(Guid id, Activity activity);

        Task<Activity?> DeleteActivityAsync(Guid id);
    }
}
