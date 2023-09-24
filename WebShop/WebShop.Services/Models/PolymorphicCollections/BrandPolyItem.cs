using WebShop.Services.Contracts;

namespace WebShop.Services.Models.PolymorphicCollections
{
    public class BrandPolyItem : IBasePolyCollection
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
