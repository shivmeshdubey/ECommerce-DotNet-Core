using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto?> GetByCodeAsync(string code);
        Task<Result<string>> AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(UpdateProductDto dto);
        Task<bool> DeleteAsync(Guid id);
    }

}
