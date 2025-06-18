namespace ECommerce.Application.DTOs.CategoryDto
{
    public class CatagoryProductDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
       public List<CatagoryProductDto> products { get; set; } = new List<CatagoryProductDto>();
    }

}
