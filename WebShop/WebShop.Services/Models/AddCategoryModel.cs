using System.ComponentModel.DataAnnotations;
using WebShop.Core.Utilities.Validation;

namespace WebShop.Services.Models
{
    public class AddCategoryModel
    {
        [Required]
        [StringLength(
            CategoryConstants.NameMaxLength,
            MinimumLength = CategoryConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SharedConstants.ImgUrlMaxLength)]
        public string CategoryImage { get; set; } = null!;
    }
}
