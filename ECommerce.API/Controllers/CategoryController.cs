using ECommerce.Application.DTOs.CategoryDto;
using ECommerce.Application.Features.Category.Command.CommandDef;
using ECommerce.Application.Features.Category.Query.QueryIRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        public readonly IMediator _mediatR;

        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _mediatR.Send(new AllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
        {
            var request = new CategoryByIdQuery(id);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetCategoryByCodeAsync(string code)
        {
            var request = new CategoryByCodeQuery(code);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            var request = new AddCategoryCommand(categoryDto);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid Id)
        {
            var request = new DeleteCategoryCommand(Id);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var request = new UpdateCategoryCommand(categoryDto);
            var result = await _mediatR.Send(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);

        }
    }
}
