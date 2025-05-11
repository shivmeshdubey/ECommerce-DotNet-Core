using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product?> GetByIdAsync(Guid id);
        public Task<Product?> GetByCodeAsync(string code);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(Guid id);
        public Task<bool> ExistsAsync(Guid id);
    }

}
