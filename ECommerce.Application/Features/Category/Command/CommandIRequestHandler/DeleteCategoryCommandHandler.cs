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
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand, Result<string>>
    {
        private readonly ICategoryServices _categoryServices;
        public DeleteCategoryCommandHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async  Task<Result<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Implement the logic to delete a category using _categoryServices

            var result = await _categoryServices.DeleteAsync(request.Id);
            if (result)
            {
                return Result<string>.Ok(request.Id.ToString(), "Category deleted successfully");
            }
            return Result<string>.Fail("Category not found");
        }
    }
    
}
