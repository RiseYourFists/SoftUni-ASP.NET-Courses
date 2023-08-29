using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Validation;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BrandConstants.NameMaxLength)]
        [Comment("Brand name")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Deletion flag")]
        public bool IsDeleted { get; set; }
    }
}
