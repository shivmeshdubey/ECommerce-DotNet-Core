using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using MediatR;


namespace ECommerce.Application.Features.Category.Query.QueryIRequest
{
    public class CategoryByCodeQuery:IRequest<Result<CategoryDto>>
    {
        public String Code { get; set; }
        public CategoryByCodeQuery(string code)
        {
            this.Code = code;
        }
    }
}
