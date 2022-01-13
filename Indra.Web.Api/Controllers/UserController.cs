using Indra.Application.Services.Interfaces;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Indra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserDTO userDto)
        {
            var response = await _userService.Insert(UserDTO.MapToUserEnity(userDto));
            return UserDTO.MapFromUserEnity(response);
        }

    }
}
