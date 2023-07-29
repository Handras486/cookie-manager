using CookieManager.Data;
using CookieManager.Models;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private readonly CookieManagerDbContext dbContext;

        public CookiesController(CookieManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            //List<Cookie> cookies = new List<Cookie>
            //{
            //    new Cookie
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Chocolate chip",
            //        CookieImageUrl = "https://images.aws.nestle.recipes/original/5b069c3ed2feea79377014f6766fcd49_Original_NTH_Chocolate_Chip_Cookie.jpg"
            //    },
            //    new Cookie
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Fortune cookie",
            //        CookieImageUrl = "https://en.wikipedia.org/wiki/Fortune_cookie#/media/File:Fortune_cookies.jpg"
            //    }
            //};

            var cookiesDomain = dbContext.Cookies.ToList();

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
        public IActionResult Get([FromRoute] Guid id)
        {
            var cookieDomain = dbContext.Cookies.FirstOrDefault(x => x.Id == id);

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
        public IActionResult Create([FromBody] AddCookieRequestDTO addCookie)
        {
            var cookieDomain = new Cookie
            {
                CookieImageUrl = addCookie.CookieImageUrl,
                Name = addCookie.Name
            };

            dbContext.Add(cookieDomain);
            dbContext.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateCookieRequestDTO updateCookie)
        {
            var cookieDomain = dbContext.Cookies.FirstOrDefault(dbContext => dbContext.Id == id);

            if (cookieDomain == null) 
                return NotFound();

            cookieDomain.CookieImageUrl = updateCookie.CookieImageUrl;
            cookieDomain.Name = updateCookie.Name;

            dbContext.SaveChanges();

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
        public IActionResult Delete([FromRoute] Guid id)
        {
            var cookieDomain = dbContext.Cookies.FirstOrDefault(x => x.Id == id);

            if(cookieDomain == null)
                return NotFound();

            dbContext.Cookies.Remove(cookieDomain);
            dbContext.SaveChanges();

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
