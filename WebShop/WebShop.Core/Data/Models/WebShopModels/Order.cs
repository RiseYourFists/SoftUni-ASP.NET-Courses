using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("Customer Id, User Identity Id")]
        public string ClientId { get; set; } = null!;

        [Required]
        [Comment("Date of order")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Comment("Flag for if an order is finished")]
        public bool IsOpen { get; set; }

        [Required]
        [Comment("Finished date of order")]
        public DateTime OrderFulfilledDate { get; set; }
    }
}
