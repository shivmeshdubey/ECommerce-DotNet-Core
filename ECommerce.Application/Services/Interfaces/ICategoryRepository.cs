using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<Category?> GetByCodeAsync(string code);
        Task<List<Category>> GetCategoriesAsync();
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
      
    }

}
