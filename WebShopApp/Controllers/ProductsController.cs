using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebShop.Services.Contracts;
using WebShopApp.Models;

namespace WebShopApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductService service,
            IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public IActionResult Add()
        {

            return View();
        }
        
    }
}
