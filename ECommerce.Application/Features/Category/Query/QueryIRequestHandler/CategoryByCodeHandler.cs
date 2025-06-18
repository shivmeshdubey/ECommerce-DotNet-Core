using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.Features.Category.Query.QueryIRequest;
using ECommerce.Application.Services.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Category.Query.QueryIRequestHandler
{
    public class CategoryByCodeHandler : IRequestHandler<CategoryByCodeQuery, Result<CategoryDto>>
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryByCodeHandler(ICategoryServices categoryServices) {
            _categoryServices = categoryServices;
        }
        public async Task<Result<CategoryDto>> Handle(CategoryByCodeQuery request, CancellationToken cancellationToken)
        {
            
            var category = await _categoryServices.GetByCodeAsync(request.Code);
            if (category == null)
            {
                return Result<CategoryDto>.Fail("Category not found");
            }
            return Result<CategoryDto>.Ok(category);
        }
    }
}