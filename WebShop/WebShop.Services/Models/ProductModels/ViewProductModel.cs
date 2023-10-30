namespace WebShop.Services.Models.ProductModels
{
    public class ViewProductModel
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ProductImage { get; set; } = null!;

        public decimal Price { get; set; }
        
        public decimal PromotionalPrice { get; set; }

        public int StockQuantity { get; set; }

        public string Brand { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
