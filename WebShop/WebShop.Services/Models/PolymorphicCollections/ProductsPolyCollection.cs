using WebShop.Services.Contracts;

namespace WebShop.Services.Models.PolymorphicCollections
{
    public class ProductsPolyCollection : IBasePolyCollection
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public decimal CurrentPrice { get; set; }
    }
}
