using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Utilities.Validation;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(ProductConstants.NameMaxLength)]
        [Comment("Product Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ProductConstants.DescriptionMaxLength)]
        [Comment("Product description")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(SharedConstants.ImgUrlMaxLength)]
        [Comment("Product image")]
        public string ProductImage { get; set; } = null!;

        [Required]
        [Comment("Regular (base) price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Active price with applied promotions")]
        public decimal PromotionalPrice { get; set; }

        [Required]
        [Comment("Quantity in stock")]
        public int StockQuantity { get; set; }

        [Required]
        [Comment("Brand reference")]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))] 
        public Brand Brand { get; set; } = null!;

        [Required]
        [Comment("Category reference")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))] 
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Deletion flag")]
        public bool IsDeleted { get; set; }
    }
}
