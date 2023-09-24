using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using WebShop.App.Models;
using WebShop.Core.Utilities.GlobalVariables;
using WebShop.Services.Contracts;
using WebShop.Services.Enums;
using WebShop.Services.Models;
using WebShop.Services.Models.ProductModels;

namespace WebShop.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService service;

        public HomeController(ILogger<HomeController> logger, IProductService _service)
        {
            _logger = logger;
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(
            int? categoryId,
            int? page,
            string? searchTerm,
            ProductOrder orderBy
        )
        {
            var categories = await service
                .AllCategories();

            var productCount = await service.FilteredProductsCount(categoryId, searchTerm);

            var pageInfo = new SearchProductViewModel()
            {
                ItemsPerPage = 12,
                CurrentPage = 1,
                OrderBy = orderBy,
                CategoryId = categoryId,
                SearchTerm = searchTerm,
                Categories = categories,
                ProductCount = productCount
            };


            if (page != null)
            {
                var pages = pageInfo.ProductCount / pageInfo.ItemsPerPage;

                if (page >= 1 || page <= pages)
                {
                    pageInfo.CurrentPage = (int)page;
                }
            }

            var products = await service
                .AllProducts(categoryId, searchTerm, orderBy, pageInfo.ItemsPerPage, pageInfo.CurrentPage);

            pageInfo.Products = products;

            return View(pageInfo);
        }

        

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}