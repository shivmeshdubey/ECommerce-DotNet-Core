using ECommerce.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.CommandDef
{
    public class DeleteProductCommand:IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public DeleteProductCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
