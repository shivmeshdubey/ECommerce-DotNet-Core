using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using MediatR;


namespace ECommerce.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand:IRequest<Result<string>>
    {
        public UserLoginDto LoginDto { get; set; } = new UserLoginDto();
        public LoginUserCommand(UserLoginDto userLoginDto)
        {
            LoginDto = userLoginDto ?? throw new ArgumentNullException(nameof(userLoginDto), "User login DTO cannot be null");
        }
    }
}
