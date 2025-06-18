using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Features.Products.Query.QueryIRequest;
using ECommerce.Application.Services;
using ECommerce.Application.Services.Interfaces;
using MediatR;


namespace ECommerce.Application.Features.Products.Query.QueryIRequestHandler
{
    public class AllCategoriesQueryHandler:IRequestHandler<AllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;
        public AllCategoriesQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<ProductDto>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync();
        }
    }
   
}
