using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class PromotionDiscount
    {
        public PromotionDiscount()
        {
            Products = new HashSet<Product>();
            Categories = new HashSet<Category>();
            Brands = new HashSet<Brand>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("Promotion reference")]
        public Guid PromotionId { get; set; }

        [ForeignKey(nameof(PromotionId))] 
        public Promotion Promotion { get; set; } = null!;

        [Comment("Product reference (optional)")]
        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ICollection<Product> Products { get; set; }

        [Comment("Category reference (optional)")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ICollection<Category> Categories { get; set; }

        [Comment("Brand reference (optional)")]
        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public ICollection<Brand> Brands { get; set; }
    }
}
