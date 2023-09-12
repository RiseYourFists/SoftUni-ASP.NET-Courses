namespace WebShop.Services.Models.ProductModels
{
    public class ProductCardViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal PromotionalPrice { get; set; }

        public string ProductImage { get; set; } = null!;

        public string Brand { get; set; } = null!;
    }
}
