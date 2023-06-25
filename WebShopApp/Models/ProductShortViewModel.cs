namespace WebShop.App.Models
{
    public class ProductShortViewModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
