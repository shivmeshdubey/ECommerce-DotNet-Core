using ECommerce.Application.Common;
using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto?> GetByCodeAsync(string code);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<Result<string>> AddAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
