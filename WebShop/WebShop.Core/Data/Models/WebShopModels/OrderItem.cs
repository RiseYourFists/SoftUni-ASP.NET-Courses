using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Core.Data.Models.WebShopModels
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("Order reference")]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(OrderId))] 
        public Order Order { get; set; } = null!;

        [Required]
        [Comment("Product reference")]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Required]
        [Comment("Stock quantity")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Deletion flag")]
        public bool IsDeleted { get; set; }
    }
}
