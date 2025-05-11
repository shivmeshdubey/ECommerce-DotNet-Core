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
        Task AddAsync(Category CategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
