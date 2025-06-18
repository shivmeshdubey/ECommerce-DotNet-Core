using ECommerce.Application.DTOs.UserDtos;
using MediatR;

namespace ECommerce.Application.Features.UserCommandQueries.Query.GetAllUser
{
    public class UserQuery : IRequest<List<UserDto>>
    {

    }
}
