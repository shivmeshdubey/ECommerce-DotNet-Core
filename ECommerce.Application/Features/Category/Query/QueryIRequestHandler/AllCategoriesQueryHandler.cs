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
    public class AllCategoriesQueryHandler:IRequestHandler<AllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryServices _categoryServices;
        public AllCategoriesQueryHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(AllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryServices.GetAllAsync();
            return result;
        }
    }
}
