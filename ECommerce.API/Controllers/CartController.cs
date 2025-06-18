using ECommerce.Application.DTOs.CartDtos;
using ECommerce.Application.DTOs.CartItemDtos;
using ECommerce.Application.Features.Carts.Command.CartCommand;
using ECommerce.Application.Features.Carts.Query.CartQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-cart-item")]
        public async Task<IActionResult> GetCartItemByUidAndPidAsync([FromBody] GetCartItemDto dto)
        {
            var query = new GetCartItemByUserAndProductQuery(dto);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetCartByUserIdAsync(Guid userId)
        {
            var query = new GetCartByUserIdQuery(userId);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCartAsync([FromBody] AddToCartDto addToCartDto)
        {
            var command = new AddToCartCommand(addToCartDto);
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                var aResult = CreatedAtAction(
                   actionName: nameof(GetCartByUserIdAsync),
                   routeValues: new { userId = addToCartDto.UserId },
                   value: addToCartDto);
                return Ok(aResult.Value);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("clear/{userId:guid}")]
        public async Task<IActionResult> ClearCartAsync(Guid userId)
        {
            var command = new ClearCartCommand(userId);
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("remove-item")]
        public async Task<IActionResult> RemoveCartItemAsync([FromBody]deleteCartItemDto removeCartItemDto)
        {
            var command = new RemoveCartItemCommand(removeCartItemDto);
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPut("update-item")]
        public async Task<IActionResult> UpdateCartItemAsync(UpdateCartItemDto updateCartItemDto)
        {
            var command = new UpdateCartItemQuantityCommand(updateCartItemDto);
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
