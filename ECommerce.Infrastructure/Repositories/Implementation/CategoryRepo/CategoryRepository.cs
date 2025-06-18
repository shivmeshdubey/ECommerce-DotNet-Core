using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories.Implementation.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        public AppDbContext appdbContext { get; set; }
        public CategoryRepository(AppDbContext appdbContext) { this.appdbContext = appdbContext; }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                await appdbContext.Categories.AddAsync(category);
                await appdbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed  
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            try
            {
                var category = await appdbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category != null)
                {
                    appdbContext.Categories.Remove(category);
                    appdbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed  
                return false;
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            var category = await appdbContext.Categories.Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await appdbContext.Categories
                .Include(c => c.Products).ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                appdbContext.Categories.Update(category);
                await appdbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await appdbContext.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<Category?> GetByCodeAsync(string code)
        {
            var category = await appdbContext.Categories.Include(c => c.Products)
                 .FirstOrDefaultAsync(c => c.Code == code);

            return category;
        }
    }
       
}
