using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Features.Products.Query.QueryIRequest;
using ECommerce.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Query.QueryIRequestHandler
{
    public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductService _productService;
        public ProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result<ProductDto>> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);
            if (product == null)
            {
                return Result<ProductDto>.Fail("Product not found");
            }
            return Result<ProductDto>.Ok(product);
        }
    }
}
