using ECommerce.Application.Common;
using ECommerce.Application.DTOs.User;
using ECommerce.Application.Features.User.Query.GetUserById;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.User.Command.UpdateUser
{
    public class UpdateUserCommandHandeler:IRequestHandler<UpdateUserCommand,string>
    {
        public IUserServices UserServices;
        public UpdateUserCommandHandeler(IUserServices userServices)
        {
            this.UserServices = userServices;
        }
        public async Task<string> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = await UserServices.UpdateUserAsync(command.UserDto);
            return response.Message.ToString();
        }
    }
}
