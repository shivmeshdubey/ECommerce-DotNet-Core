using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.Features.Category.Query.QueryIRequest;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Query.QueryIRequestHandler
{
    public class CategoryByIdQueryHandler:IRequestHandler<CategoryByIdQuery, Result<CategoryDto>>
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryByIdQueryHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<Result<CategoryDto>> Handle(CategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var category = await _categoryServices.GetByIdAsync(request.Id);
            if (category == null)
            {
                return Result<CategoryDto>.Fail("Category not found");
            }
            return Result<CategoryDto>.Ok(category);
        }
    }
}
