using Microsoft.AspNetCore.Mvc;
using TOGItemManager.Application.DTOs.Auth.Requests;
using TOGItemManager.Application.Services.Auth.Interfaces;

namespace TOGItemManager.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // [Authorize]
        // [HttpGet("teste-auth")]
        // public IActionResult TesteAuth()
        // {
        //     return Ok("Você está autenticado");
        // }
        
        // [Authorize]
        // [HttpGet("quem-sou-eu")]
        // public IActionResult QuemSouEu()
        // {
        //     return Ok(new
        //     {
        //         Usuario = User.Identity?.Name,
        //         Claims = User.Claims.Select(c => new { c.Type, c.Value })
        //     });
        // }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = authService.Login(request);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(new {message = ex.Message});
            }
        }
    }
}