using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.Features.Category.Command.CommandDef;
using ECommerce.Application.Services.Interfaces;
using MediatR;


namespace ECommerce.Application.Features.Category.Command.CommandHandler
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand, Result<UpdateCategoryDto>>
    {
        private readonly ICategoryServices _categoryServices;
        public UpdateCategoryCommandHandler(ICategoryServices categoryService)
        {
            _categoryServices = categoryService;
        }
        public async Task<Result<UpdateCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
           var result = await _categoryServices.UpdateAsync(request.updateCategoryDto);
            if (result)
            {
                var categoryResult = await _categoryServices.GetByIdAsync(request.updateCategoryDto.Id);
                var category = new UpdateCategoryDto
                {
                    Id = categoryResult.Id,
                    Name = categoryResult.Name,
                    Code = categoryResult.Code,
                };
                return Result<UpdateCategoryDto>.Ok(category, "Category updated successfully");
            }
            return Result<UpdateCategoryDto>.Fail("Category not found");
        }
    }
}
