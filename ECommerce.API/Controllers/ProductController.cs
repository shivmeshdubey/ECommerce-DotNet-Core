using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.DTOs.ProductDtos;
using ECommerce.Application.Features.Category.Command.CommandDef;
using ECommerce.Application.Features.Category.Query.QueryIRequest;
using ECommerce.Application.Features.Products.Command.CommandDef;
using ECommerce.Application.Features.Products.Query.QueryIRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        public readonly IMediator _mediatR;

        public ProductController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var categories = await _mediatR.Send(new AllProductsQuery());
            return Ok(categories);
        }
        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid Id)
        {
            var result = await _mediatR.Send( new ProductByIdQuery(Id));

            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetProductByCodeAsync(string code)
        {
            var result = await _mediatR.Send(new ProductByCodeQuery(code));

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand(updateProductDto);
            var result = await _mediatR.Send(command);
            if (result.Success)
            {
                return Ok(CreatedAtAction(nameof(GetProductByIdAsync), new { id = updateProductDto.Id }, updateProductDto));
            }
            return BadRequest(result.Message);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var command = new DeleteProductCommand(Id);
            var result = await _mediatR.Send(command);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(CreateProductDto dto)
        {
            var request = new AddProductCommand(dto);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
