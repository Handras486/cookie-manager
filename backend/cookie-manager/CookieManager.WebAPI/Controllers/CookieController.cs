using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCookies()
        {
            string[] cookies = new string[] { "chocolate chip", "vanilla", "mint" };  
            
            return Ok(cookies);
        }
    }
}
