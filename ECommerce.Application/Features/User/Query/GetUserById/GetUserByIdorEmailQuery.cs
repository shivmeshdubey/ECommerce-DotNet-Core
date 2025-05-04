using ECommerce.Application.Common;
using ECommerce.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.User.Query.GetUserById
{
    public class GetUserByIdorEmailQuery:IRequest<Result<UserDto>>
    {
        public GetUserByIdorEmailDto getEorIdDto {  get; set; }
        public GetUserByIdorEmailQuery(GetUserByIdorEmailDto getUserByIdorEmailDto) { this.getEorIdDto = getUserByIdorEmailDto; }

    }
}
