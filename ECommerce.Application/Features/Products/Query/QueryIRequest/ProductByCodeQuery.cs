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
    public  class ProductByCodeQuery:IRequest<Result<ProductDto>>
    {
        public string Code { get; set; }
        public ProductByCodeQuery(string code)
        {
            Code = code;
        }
    }
   
}
