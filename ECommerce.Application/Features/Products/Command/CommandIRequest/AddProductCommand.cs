using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.CommandDef
{
    public class AddProductCommand:IRequest<Result<string>>
    {
        public CreateProductDto createProductDto { get; set; }
        public AddProductCommand(CreateProductDto createProductDto)
        {
            this.createProductDto = createProductDto;
        }
    }
}
