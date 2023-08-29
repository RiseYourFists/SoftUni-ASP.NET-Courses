using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Validation;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Promotion
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PromotionConstants.NameMaxLength)]
        [Comment("Promotion title")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Promotion start date")]
        public DateOnly StartDate { get; set; }

        [Required]
        [Comment("Promotion end date")]
        public DateOnly EndDate { get; set; }
    }
}
