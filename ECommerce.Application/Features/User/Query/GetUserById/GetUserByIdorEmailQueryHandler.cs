using ECommerce.Application.Common;
using ECommerce.Application.DTOs.User;
using ECommerce.Application.Features.User.Query.User;
using ECommerce.Application.Services.Interfaces.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.User.Query.GetUserById
{
    public class GetUserByIdorEmailQueryHandler:IRequestHandler<GetUserByIdorEmailQuery, Result<UserDto>>
    {
        public IUserServices UserServices;
        public GetUserByIdorEmailQueryHandler(IUserServices userServices)
        {
            this.UserServices = userServices;
        }
        public async Task<Result<UserDto>> Handle(GetUserByIdorEmailQuery query, CancellationToken cancellationToken)
        {
            var response = await UserServices.GetUserByEmailorIDAsync(query.getEorIdDto);
           if(response.Success)
            {
                return Result<UserDto>.Ok(response.Data);
            }
            return Result<UserDto>.Fail(response.Message); 
        }
    }
}
