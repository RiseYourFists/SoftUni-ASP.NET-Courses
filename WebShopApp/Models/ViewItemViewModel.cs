using System.ComponentModel.DataAnnotations;
using WebShop.Core;

namespace WebShop.App.Models
{
    public class ViewItemViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? ProductDescription { get; set; }
    }
}

