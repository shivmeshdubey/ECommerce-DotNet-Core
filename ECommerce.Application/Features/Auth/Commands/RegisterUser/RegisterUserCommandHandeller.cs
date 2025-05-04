using ECommerce.Application.Common;
using ECommerce.Application.Services.Interfaces.Auth;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace ECommerce.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandeller:IRequestHandler<RegisterUserCommand,Result<string>>
    {
        
        public IUserServices userServices;
        public RegisterUserCommandHandeller(IUserServices userServices)
        {
            this.userServices = userServices;
        }   

        public async Task<Result<string>> Handle(RegisterUserCommand command,CancellationToken cancellationToken)
        {

            var responce = await userServices.ResisterAsync(command.userRegisterDto);
            if (responce.Success)
            {
                return Result<string>.Ok(responce.Data,responce.Message);
            }
            else
            {
                return Result<string>.Fail( responce.Message);
            }
        }
    }
}
