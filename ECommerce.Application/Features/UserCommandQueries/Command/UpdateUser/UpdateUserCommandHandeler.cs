using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;

namespace ECommerce.Application.Features.UserCommandQueries.Command.UpdateUser
{
    public class UpdateUserCommandHandeler : IRequestHandler<UpdateUserCommand, string>
    {
        public IUserServices UserServices;
        public UpdateUserCommandHandeler(IUserServices userServices)
        {
            UserServices = userServices;
        }
        public async Task<string> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = await UserServices.UpdateUserAsync(command.UserDto);
            return response.Message.ToString();
        }
    }
}
