using AutoMapper;
using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using CookieManager.Service;
using CookieManager.Service.Interfaces;
using CookieManager.WebAPI.CustomActionFilters;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        private readonly IActivityService activityService;
        private readonly IMapper mapper;

        public ActivitesController(IActivityService activityService, IMapper mapper)
        {
            this.activityService = activityService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activityDomain = await activityService.GetAllActivitiesAsync();

            return Ok(mapper.Map<List<ActivityDTO>>(activityDomain));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var activityDomain = await activityService.GetActivityAsync(id);

            if (activityDomain == null)
                return NotFound();

            return Ok(mapper.Map<ActivityDTO>(activityDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] ActivityDTO addActivity)
        {
            var activityDomain = mapper.Map<Activity>(addActivity);

            await activityService.CreateActivityAsync(activityDomain);

            var activityDTO = mapper.Map<ActivityDTO>(activityDomain);

            return CreatedAtAction(nameof(Get), new { id = activityDTO.Id }, activityDTO);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ActivityDTO updateActivity)
        {
            var activityDomain = mapper.Map<Activity>(updateActivity);

            activityDomain = await activityService.UpdateActivityAsync(id, activityDomain);

            if (activityDomain == null)
                return NotFound();

            return Ok(mapper.Map<ActivityDTO>(activityDomain));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var activityDomain = await activityService.DeleteActivityAsync(id);

            if (activityDomain == null)
                return NotFound();

            return Ok(mapper.Map<ActivityDTO>(activityDomain));
        }

    }
}
