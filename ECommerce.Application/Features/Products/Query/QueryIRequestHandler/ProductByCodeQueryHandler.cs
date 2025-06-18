using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Features.Products.Query.QueryIRequest;
using ECommerce.Application.Services;
using MediatR;

public class ProductByCodeQueryHandler : IRequestHandler<ProductByCodeQuery, Result<ProductDto>>
{
    private readonly IProductService _productService;

    public ProductByCodeQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Result<ProductDto>> Handle(ProductByCodeQuery request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetByCodeAsync(request.Code);

        if (result != null)
        {
            return Result<ProductDto>.Ok(result);
        }

        return Result<ProductDto>.Fail("Product not found");
    }
}
