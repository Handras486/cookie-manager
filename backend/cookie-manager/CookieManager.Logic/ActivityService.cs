using CookieManager.Service.Interfaces;
using CookieManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieManager.Repository.Interfaces;
using System.Net;
using AutoMapper;

namespace CookieManager.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IMapper mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            this.activityRepository = activityRepository;
            this.mapper = mapper;
        }

        public async Task<Activity> CreateActivityAsync(Activity createActivity)
        {
            await activityRepository.CreateAsync(createActivity);
            return createActivity;
        }

        public async Task<Activity?> DeleteActivityAsync(Guid id)
        {
            var deleteActivity = await activityRepository.DeleteAsync(id);
            return deleteActivity;
        }

        public async Task<Activity?> GetActivityAsync(Guid id)
        {
            return await activityRepository.GetAsync(id);
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            var allActivites = await activityRepository.GetAllAsync();
            return allActivites;
        }

        public async Task<Activity?> UpdateActivityAsync(Guid id, Activity activity)
        {
            var updateActivity = await activityRepository.UpdateAsync(id, activity);

            mapper.Map(updateActivity, activity);

            return updateActivity;
        }
    }
}
