using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Query.QueryIRequest
{
    public class ProductByIdQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
        public ProductByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
