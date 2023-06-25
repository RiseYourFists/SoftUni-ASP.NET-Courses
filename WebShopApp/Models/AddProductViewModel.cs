using System.ComponentModel.DataAnnotations;
using WebShop.App.Utilities;
using WebShop.Core;

namespace WebShop.App.Models
{
    public class AddProductViewModel
    {
        [Required]
        [MaxLength(GlobalVariables.ProductNameLength)]
        [MinLength(GlobalVariables.ProductNameMinLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(GlobalVariables.ProductPriceMinValue, GlobalVariables.ProductPriceMaxValue )]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(GlobalVariables.ProductDescriptionLength)]
        public string? ProductDescription { get; set; }
    }
}
