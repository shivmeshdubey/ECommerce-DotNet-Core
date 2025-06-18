using ECommerce.Application.Common;
using ECommerce.Application.DTOs.Order;
using MediatR;

namespace ECommerce.Application.Features.Orders.Command.OrderCommand
{
    public class CreateOrderCommand:IRequest<Result<OrderResponseDto>>
    {
        public CreateOrderDto CreateOrderDto { get; set; }
        public CreateOrderCommand(CreateOrderDto createOrderDto)
        {
            CreateOrderDto = createOrderDto ?? throw new ArgumentNullException(nameof(createOrderDto));
        }
    }
}
