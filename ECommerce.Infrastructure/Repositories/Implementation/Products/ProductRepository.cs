using ECommerce.Application.Services.Interfaces;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using ECommerce.Domain.Entities;
using ECommerce.Application.Common;

namespace ECommerce.Infrastructure.Repositories.Implementation.Products
{
    public class ProductRepository : IProductRepository
    {
        public AppDbContext appdbContext { get; set; }
        public ProductRepository(AppDbContext appdbContext) { this.appdbContext = appdbContext; }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await appdbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Product?> GetByCodeAsync(string code)
        {
            return await appdbContext.Products
                 .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await appdbContext.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await appdbContext.Products.AddAsync(product);
            await appdbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
             appdbContext.Products.Update(product);
             appdbContext.Entry(product).State = EntityState.Modified;
            await  appdbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await appdbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            appdbContext.Products.Remove(product);
            await appdbContext.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await appdbContext.Products
                .AnyAsync(p => p.Id == id);
        }
    }
}
