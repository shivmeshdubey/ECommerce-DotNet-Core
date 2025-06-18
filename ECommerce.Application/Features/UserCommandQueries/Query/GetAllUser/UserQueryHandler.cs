using ECommerce.Application.DTOs.UserDtos;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.UserCommandQueries.Query.GetAllUser
{
    public class UserQueryHandller : IRequestHandler<UserQuery, List<UserDto>>
    {
        public IUserServices UserServices;
        public UserQueryHandller(IUserServices userServices)
        {
            UserServices = userServices;
        }
        public async Task<List<UserDto>> Handle(UserQuery query, CancellationToken cancellationToken)
        {

            return await UserServices.GetAllUsersAsync();
        }
    }
}
