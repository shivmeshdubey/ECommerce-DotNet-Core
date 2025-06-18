namespace ECommerce.Application.DTOs.Order
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; } = new();
        public string ShippingAddress { get; set; } = string.Empty;
    }
}
