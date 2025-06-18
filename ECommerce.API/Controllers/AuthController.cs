using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Features.Auth.Commands.LoginUser;
using ECommerce.Application.Features.Auth.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private IMediator _mediatr;
        public AuthController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserResisterDto user)
        {
            var command = new RegisterUserCommand(user);
            var result = await _mediatr.Send(command);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto dto)
        {
            var command = new LoginUserCommand(dto);
            var result = await _mediatr.Send(command);
            if(result.Success)
            {
                return Ok( result.Data);
            }
            return BadRequest(result.Message);
             
        }
    }
}
