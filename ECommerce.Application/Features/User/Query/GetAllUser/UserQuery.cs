using ECommerce.Application.DTOs.User;
using MediatR;

namespace ECommerce.Application.Features.User.Query.User
{
    public class UserQuery:IRequest<List<UserDto>>
    {
        
    }
}
