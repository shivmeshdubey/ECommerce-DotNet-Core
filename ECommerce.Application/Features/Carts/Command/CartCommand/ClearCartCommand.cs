using ECommerce.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Carts.Command.CartCommand
{
    public class ClearCartCommand :IRequest<Result<string>>
    {
        public Guid userId;

        public ClearCartCommand(Guid userId)
        {
            this.userId = userId;
        }
    }
}
