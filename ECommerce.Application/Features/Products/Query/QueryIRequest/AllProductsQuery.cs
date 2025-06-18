using ECommerce.Application.DTOs.ProductDtos;
using MediatR;


namespace ECommerce.Application.Features.Products.Query.QueryIRequest
{
    public class AllProductsQuery:IRequest<IEnumerable<ProductDto>>
    {
    }
}
