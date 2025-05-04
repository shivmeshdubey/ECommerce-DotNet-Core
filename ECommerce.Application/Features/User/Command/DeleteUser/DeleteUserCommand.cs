using ECommerce.Application.Common;
using ECommerce.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.User.Command.DeleteUser
{
    public class DeleteUserCommand:IRequest<Result<string>>
    {
        public GetUserByIdorEmailDto GetUserByIdorEmailDto;
        public DeleteUserCommand(GetUserByIdorEmailDto getUserByIdorEmailDto)
        {
            GetUserByIdorEmailDto = getUserByIdorEmailDto;
        }
    }
}
