using ECommerce.Application.DTOs.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.UserCommandQueries.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<string>
    {
        public UserDto UserDto { get; set; }
        public UpdateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
