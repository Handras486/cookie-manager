using CookieManager.Repository;
using CookieManager.Service.Interfaces;
using CookieManager.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace CookieManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenService tokenService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);

            if (identityResult.Succeeded)
            {
                if (!registerRequest.Roles.IsNullOrEmpty()) 
                { 
                   identityResult = await userManager.AddToRolesAsync(identityUser, registerRequest.Roles);

                    if (identityResult.Succeeded)
                        return Ok("User was registered!");
                }
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequest.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenService.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO() { JwtToken = jwtToken };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect!");
        }
    }
}
