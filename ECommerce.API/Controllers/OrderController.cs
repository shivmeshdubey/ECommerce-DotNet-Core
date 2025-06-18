using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Orders.Command.OrderCommand;
using ECommerce.Application.Features.Orders.Query.OrderQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediatR;
        public OrderController(IMediator mediatR)
        {
            this.mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders = await mediatR.Send(new GetAllOrdersQuery());
            if (orders.Success)
            {
                return Ok(orders.Data);
            }
            return NotFound(orders.Message);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderByIdAsync(Guid id)
        {
            var result = await mediatR.Send(new GetOrderByIdQuery(id));
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId)
        {
            var result = await mediatR.Send(new GetOrdersByUserIdQuery(userId));
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto)
        {
            var command = new UpdateOrderStatusCommand(updateOrderStatusDto);
            var result = await mediatR.Send(command);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            var command = new DeleteOrderCommand(id);
            var result = await mediatR.Send(command);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var command = new CreateOrderCommand(createOrderDto);
            var result = await mediatR.Send(command);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
