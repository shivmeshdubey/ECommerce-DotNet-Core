using ECommerce.Application.Common;
using ECommerce.Application.DTOs.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.UserCommandQueries.Query.GetUserById
{
    public class GetUserByIdorEmailQuery : IRequest<Result<UserDto>>
    {
        public GetUserByIdorEmailDto getEorIdDto { get; set; }
        public GetUserByIdorEmailQuery(GetUserByIdorEmailDto getUserByIdorEmailDto) { getEorIdDto = getUserByIdorEmailDto; }

    }
}
