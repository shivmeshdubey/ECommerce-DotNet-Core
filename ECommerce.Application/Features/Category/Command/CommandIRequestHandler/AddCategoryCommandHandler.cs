using ECommerce.Application.Common;
using ECommerce.Application.Features.Category.Command.CommandDef;
using ECommerce.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Command.CommandHandler
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Result<string>>
    {
        private readonly ICategoryServices _categoryServices;
        public AddCategoryCommandHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<Result<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryServices.AddAsync(request.CategoryDto);
            if (result.Success)
            {
                return Result<string>.Ok(result.Data,"Category added successfully");
            }
            return Result<string>.Fail("Failed to add category");
        }
    }
}
