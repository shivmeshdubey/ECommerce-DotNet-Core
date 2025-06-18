using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerce.Application.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Application.Features.UserCommandQueries.Query.GetAllUser;
using ECommerce.Application.Features.UserCommandQueries.Command.DeleteUser;
using ECommerce.Application.Features.UserCommandQueries.Query.GetUserById;
using ECommerce.Application.Features.UserCommandQueries.Command.UpdateUser;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser( UserDto dto)
        {
            var result = await _meduatR.Send(new UpdateUserCommand(dto));
            return Ok(new { Success = result });
        }

    }
}
