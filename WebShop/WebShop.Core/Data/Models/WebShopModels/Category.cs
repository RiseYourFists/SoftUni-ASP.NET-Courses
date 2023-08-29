using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Validation;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.NameMaxLength)]
        [Comment("Brand name")]
        public string Name { get; set; } = null!;

        [StringLength(SharedConstants.ImgUrlMaxLength)]
        [Comment("Category img")]
        public string? BrandImg { get; set; }

        [Required]
        [Comment("Deletion flag")]
        public bool IsDeleted { get; set; }
    }
}
