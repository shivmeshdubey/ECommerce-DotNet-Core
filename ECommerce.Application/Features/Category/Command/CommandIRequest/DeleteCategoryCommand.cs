using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Command.CommandDef
{
    public class DeleteCategoryCommand:IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public DeleteCategoryCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
