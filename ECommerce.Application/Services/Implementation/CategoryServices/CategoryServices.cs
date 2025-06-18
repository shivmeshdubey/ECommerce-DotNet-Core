
using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Implementation.CategoryServices
{
    public class CategoryServices: ICategoryServices
    {
        public ICategoryRepository _categoryRepository { get; set; }
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
           if(category == null)
            {
                return null;
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                products = category.Products.Select(p => new CatagoryProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                }).ToList()
            };
        }
        public async Task<CategoryDto?> GetByCodeAsync(string code)
        {
            var category = await _categoryRepository.GetByCodeAsync(code);
            if (category == null)
            {
                return null;
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                products = category.Products.Select(p => new CatagoryProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                }).ToList()
            };
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            if (categories == null)
            {
                return null;
            }
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                products = c.Products.Select(p =>new CatagoryProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                }).ToList()
            }).ToList();
        }
        public async Task<Result<string>> AddAsync(CategoryDto CategoryDto)
        {
            var categoryExists = await _categoryRepository.GetByCodeAsync(CategoryDto.Code);
            if (categoryExists!=null)
            {
                return Result<string>.Fail("Category already exists!");
            }
            var category = new Category
            {
                Id= Guid.NewGuid(),
                Name = CategoryDto.Name,
                Code = CategoryDto.Code,
            };
           var result = await _categoryRepository.AddCategoryAsync(category);

            if (result && category !=null)
            {
                return Result<string>.Ok(category.Id.ToString(),"Created Successfully");
            }
            return Result<string>.Fail("Not created!");

        }
        public async Task<bool> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = new Category
            {
                Id = updateCategoryDto.Id,
                Name = updateCategoryDto.Name,
                Code = updateCategoryDto.Code,
            };

            return await _categoryRepository.UpdateCategoryAsync(category);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _categoryRepository.ExistsAsync(id);
        }

    }
}
