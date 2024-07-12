using AutoMapper;
using CookieManager.Core.Entities;
using CookieManager.Core.Specifications;
using CookieManager.Service.Interfaces;
using CookieManager.WebAPI.CustomActionFilters;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Writer,Reader")]
    public class CookiesController : ControllerBase
    {
        private readonly ICookieService cookieService;
        private readonly IMapper mapper;
        private readonly ILogger<CookiesController> logger;

        public CookiesController(ICookieService cookieService, IMapper mapper, ILogger<CookiesController> logger)
        {
            this.cookieService = cookieService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CookieQueryParameters queryParameters)
        {
            var cookieDomain = await cookieService.GetAllCookiesAsync(queryParameters);

            logger.LogInformation($"Finished GetAllCookies Action request with data: {JsonSerializer.Serialize(cookieDomain)}");

            return Ok(mapper.Map<List<CookieDTO>>(cookieDomain));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var cookieDomain = await cookieService.GetCookieAsync(id);

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

            await cookieService.CreateCookieAsync(cookieDomain);

            var cookieDTO = mapper.Map<CookieDTO>(cookieDomain);

            return CreatedAtAction(nameof(Get), new { id = cookieDTO.Id }, cookieDTO);
        }

        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCookieRequestDTO updateCookie)
        {
            var cookieDomain = mapper.Map<Cookie>(updateCookie);

            cookieDomain = await cookieService.UpdateCookieAsync(id, cookieDomain);

            if (cookieDomain == null) 
                return NotFound();

            return Ok(mapper.Map<CookieDTO>(cookieDomain));
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cookieDomain = await cookieService.DeleteCookieAsync(id);

            if(cookieDomain == null)
                return NotFound();

            return Ok(mapper.Map<CookieDTO>(cookieDomain));
        }

    }
}
