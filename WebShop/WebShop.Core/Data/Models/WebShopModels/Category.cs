using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Utilities.Validation;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [StringLength(SharedConstants.ImgUrlMaxLength)]
        [Comment("Category img")]
        public string? CategoryBannerImg { get; set; }

        [Required]
        [Comment("Deletion flag")]
        public bool IsDeleted { get; set; }
    }
}
