using ECommerce.Application.Common;
using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using System.Net.Http.Headers;

namespace ECommerce.Application.Services.Implementation.ProductsServices
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<string>> AddAsync(CreateProductDto dto) // Ensure method is marked as async
        {
            var productExists = await _productRepository.GetByCodeAsync(dto.Code); // Await the async call
            if (productExists != null)
            {
                return Result<string>.Fail("already exist");
            }
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };
            await _productRepository.AddAsync(product);
            if (product != null)
            {
                return Result<string>.Ok(product.Id.ToString(), "Successfully Created!");
            }
            return  Result<string>.Fail("unable to create!");
        }

        public async Task<bool> DeleteAsync(Guid id) // Ensure method is marked as async
        {
            var product = await _productRepository.GetByIdAsync(id); // Await the async call
            if (product == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(id); // Await the async call
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync()
                .ContinueWith(task =>
                {
                    var products = task.Result;
                    return products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Code = p.Code,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category.Name
                    });
                });
        }

        public async Task<ProductDto?> GetByCodeAsync(string code)
        {
            var product = await _productRepository.GetByCodeAsync(code); // Await the async call  
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.Name
            };
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id); // Await the async call
            if (product == null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                CategoryName = product.Name
            };
        }

        public async Task<bool> UpdateAsync(UpdateProductDto dto)
        {
            var product = await _productRepository.ExistsAsync(dto.Id); // Await the async call
            if(product == null)
            {
                return false;
            }
            await _productRepository.GetByIdAsync(dto.Id);
            return true;
        }
    }
}
