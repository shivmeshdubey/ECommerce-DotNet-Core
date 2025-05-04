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

namespace ECommerce.Application.Features.User.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        public IUserServices UserServices;
        public DeleteUserCommandHandler(IUserServices userServices)
        {
            this.UserServices = userServices;
        }
        public async Task<Result<string>> Handle(DeleteUserCommand query, CancellationToken cancellationToken)
        {
            var response = await UserServices.DeleteUserAsync(query.GetUserByIdorEmailDto);
            if (response.Success)
            {
                return Result<string>.Ok(response.Data);
            }
            return Result<string>.Fail(response.Message);
        }
    }
}
