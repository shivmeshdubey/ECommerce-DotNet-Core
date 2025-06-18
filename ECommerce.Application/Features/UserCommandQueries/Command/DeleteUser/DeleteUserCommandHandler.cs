using ECommerce.Application.Common;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;

namespace ECommerce.Application.Features.UserCommandQueries.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        public IUserServices UserServices;
        public DeleteUserCommandHandler(IUserServices userServices)
        {
            UserServices = userServices;
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
