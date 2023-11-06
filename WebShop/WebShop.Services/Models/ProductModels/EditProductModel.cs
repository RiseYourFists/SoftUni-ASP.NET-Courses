using System.ComponentModel.DataAnnotations;
using WebShop.Core.Utilities.GlobalVariables;
using WebShop.Core.Utilities.Validation;

namespace WebShop.Services.Models.ProductModels
{
    public class EditProductModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(
            ProductConstants.NameMaxLength,
            MinimumLength = ProductConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(
            ProductConstants.DescriptionMaxLength,
            MinimumLength = ProductConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(SharedConstants.ImgUrlMaxLength)]
        public string ProductImage { get; set; } = null!;

        [Required]
        [Range(
        typeof(decimal),
            ProductConstants.PriceMinValue,
            ProductConstants.PriceMaxValue,
            ErrorMessage = ErrorMessages.ValueOutOfRange)]
        public decimal Price { get; set; }

        [Required]
        [Range(
        typeof(decimal),
            ProductConstants.PriceMinValue,
            ProductConstants.PriceMaxValue,
            ErrorMessage = ErrorMessages.ValueOutOfRange)]
        public decimal PromotionalPrice { get; set; }
        [Required]
        [Range(
            ProductConstants.QuantityMinRange,
            ProductConstants.QuantityMaxRange,
            ErrorMessage = ErrorMessages.ValueOutOfRange)]
        public int StockQuantity { get; set; }

        [Required]
        public int BrandId { get; set; }

        public List<BrandListModel> Brands { get; set; } = new List<BrandListModel>();

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryListModel> Categories { get; set; } = new List<CategoryListModel>();
    }
}
