using CookieManager.Models;
using CookieManager.Repository;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private readonly ICookieRepository cookieRepository;

        public CookiesController(ICookieRepository cookieRepository)
        {
            this.cookieRepository = cookieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cookiesDomain = await cookieRepository.GetAllAsync();

            var cookiesDTO = new List<CookieDTO>();
            foreach (var cookieDomain in cookiesDomain)
            {
                cookiesDTO.Add(new CookieDTO()
                {
                    Name = cookieDomain.Name,
                    Id = cookieDomain.Id,
                    CookieImageUrl = cookieDomain.CookieImageUrl
                });
            }

            return Ok(cookiesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var cookieDomain = await cookieRepository.GetAsync(id);

            if (cookieDomain == null)
                return NotFound();

            var cookieDTO = new CookieDTO()
            {
                CookieImageUrl = cookieDomain.CookieImageUrl,
                Id = cookieDomain.Id,
                Name = cookieDomain.Name
            };

            return Ok(cookieDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCookieRequestDTO addCookie)
        {
            var cookieDomain = new Cookie
            {
                CookieImageUrl = addCookie.CookieImageUrl,
                Name = addCookie.Name
            };

            await cookieRepository.CreateAsync(cookieDomain);

            var cookieDTO = new CookieDTO
            {
                CookieImageUrl = cookieDomain.CookieImageUrl,
                Name = cookieDomain.Name,
                Id = cookieDomain.Id
            };

            return CreatedAtAction(nameof(Get), new { id = cookieDTO.Id }, cookieDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCookieRequestDTO updateCookie)
        {
            var cookieDomain = new Cookie
            {
                CookieImageUrl = updateCookie.CookieImageUrl,
                Name = updateCookie.Name
            };

            cookieDomain = await cookieRepository.UpdateAsync(id, cookieDomain);

            if (cookieDomain == null) 
                return NotFound();

            var cookieDTO = new CookieDTO
            {
                Name = cookieDomain.Name,
                CookieImageUrl = cookieDomain.CookieImageUrl,
                Id = cookieDomain.Id
            };

            return Ok(cookieDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cookieDomain = await cookieRepository.DeleteAsync(id);

            if(cookieDomain == null)
                return NotFound();

            var cookieDTO = new CookieDTO
            {
                Name = cookieDomain.Name,
                CookieImageUrl = cookieDomain.CookieImageUrl,
                Id = cookieDomain.Id
            };

            return Ok(cookieDTO);
        }

    }
}
