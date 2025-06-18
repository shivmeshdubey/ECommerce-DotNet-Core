using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<Result<string>>
    {
        public UserResisterDto userRegisterDto { get; set; }

        public RegisterUserCommand(UserResisterDto userRegisterDto)
        {
            this.userRegisterDto = userRegisterDto;
        }

    }
}
