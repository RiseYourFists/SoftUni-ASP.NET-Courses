using System.ComponentModel.DataAnnotations;
using WebShop.Core.Utilities.Validation;

namespace WebShop.Services.Models
{
    public class AddBrandModel
    {
        [Required]
        [StringLength(
            BrandConstants.NameMaxLength,
            MinimumLength = BrandConstants.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SharedConstants.ImgUrlMaxLength)]
        public string BrandLogoImgUrl { get; set; } = null!;
    }
}
