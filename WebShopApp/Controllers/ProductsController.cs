using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebShopApp.Models;

namespace WebShopApp.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 2.40
            },
            new ProductViewModel() 
            {
                Id = 2,
                Name = "Milk",
                Price = 2.00
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Butter",
                Price = 5.30
            }
        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = products
                    .Where(p =>
                        p.Name.ToLower()
                            .Contains(keyword.ToLower()));

                return View(foundProducts);
            }

            return View(this.products);
        }

        
        public IActionResult ById(int id)
        {
            var result = this.products.FirstOrDefault(p => p.Id == id);

            if (result == null)
            {
                return BadRequest();
            }
            return View(result);
        }
        
        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var sb = new StringBuilder();

            foreach (var product in this.products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            return Content(sb.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            var sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2} lv.");
            }

            Response.Headers
                .Add(HeaderNames.ContentDisposition,
                    @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
