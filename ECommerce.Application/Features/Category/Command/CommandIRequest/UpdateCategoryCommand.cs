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
    public class UpdateCategoryCommand:IRequest<Result<UpdateCategoryDto>>
    {
        public UpdateCategoryDto updateCategoryDto { get; set; }
        public UpdateCategoryCommand(UpdateCategoryDto updateCategoryDto)
        {
            this.updateCategoryDto = updateCategoryDto;
        }
    }
}
