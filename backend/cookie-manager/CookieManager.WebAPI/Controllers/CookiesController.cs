using AutoMapper;
using CookieManager.Models;
using CookieManager.Repository;
using CookieManager.WebAPI.CustomActionFilters;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private readonly ICookieRepository cookieRepository;
        private readonly IMapper mapper;

        public CookiesController(ICookieRepository cookieRepository, IMapper mapper)
        {
            this.cookieRepository = cookieRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var cookieDomain = await cookieRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<CookieDTO>>(cookieDomain));
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var cookieDomain = await cookieRepository.GetAsync(id);

            if (cookieDomain == null)
                return NotFound();

            return Ok(mapper.Map<CookieDTO>(cookieDomain));
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddCookieRequestDTO addCookie)
        {
            var cookieDomain = mapper.Map<Cookie>(addCookie);

            await cookieRepository.CreateAsync(cookieDomain);

            var cookieDTO = mapper.Map<CookieDTO>(cookieDomain);

            return CreatedAtAction(nameof(Get), new { id = cookieDTO.Id }, cookieDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCookieRequestDTO updateCookie)
        {
            var cookieDomain = mapper.Map<Cookie>(updateCookie);

            cookieDomain = await cookieRepository.UpdateAsync(id, cookieDomain);

            if (cookieDomain == null) 
                return NotFound();

            return Ok(mapper.Map<CookieDTO>(cookieDomain));
        }

        [HttpDelete]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cookieDomain = await cookieRepository.DeleteAsync(id);

            if(cookieDomain == null)
                return NotFound();

            return Ok(mapper.Map<CookieDTO>(cookieDomain));
        }

    }
}
