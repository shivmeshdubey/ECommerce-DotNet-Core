using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerce.Application.Features.User.Query.User;
using ECommerce.Application.Features.User.Query.GetUserById;
using ECommerce.Application.DTOs.User;
using ECommerce.Application.Features.User.Command.DeleteUser;
using ECommerce.Application.Features.User.Command.UpdateUser;
using Microsoft.AspNetCore.Authorization;
namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _meduatR;
        public UserController(IMediator meduatR)
        {
            _meduatR = meduatR;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _meduatR.Send(new UserQuery());
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id){
            GetUserByIdorEmailDto dto = new GetUserByIdorEmailDto
            {
                Id = id,
                Email = string.Empty,
            };
            var request = new GetUserByIdorEmailQuery(dto);

           var result = await _meduatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            GetUserByIdorEmailDto dto = new GetUserByIdorEmailDto
            {
                Id = null,
                Email = email,
            };
            var request = new GetUserByIdorEmailQuery(dto);

            var result = await _meduatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid id)
        {
            GetUserByIdorEmailDto dto = new GetUserByIdorEmailDto
            {
                Id = id,
                Email = string.Empty,
            };
            var request = new DeleteUserCommand(dto);

            var result = await _meduatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUserByEmailAsync(string email)
        {
            GetUserByIdorEmailDto dto = new GetUserByIdorEmailDto
            {
                Id = null,
                Email = email,
            };
            var request = new DeleteUserCommand(dto);

            var result = await _meduatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

 
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser( UserDto dto)
        {
            var result = await _meduatR.Send(new UpdateUserCommand(dto));
            return Ok(new { Success = result });
        }

    }
}
