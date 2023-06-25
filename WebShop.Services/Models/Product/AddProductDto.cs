using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Services.Models.Product
{
    public class AddProductDto
    {
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }
    }
}
