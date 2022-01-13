using Indra.Application.Services.Interfaces;
using Indra.Web.Dto.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Indra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthorizationController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] UserLoginDTO login)
        {
            var token = await _jwtService.GetToken(UserLoginDTO.MapToUserLoginEntity(login));
            if (token == null)
                return BadRequest($"wrong user or password");
            return Ok(UserTokenDTO.MapFromUserTokenEntity(token));
        }

    }
}
