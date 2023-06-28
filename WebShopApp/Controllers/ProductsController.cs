using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using WebShop.App.Models;
using WebShop.Services.Contracts;
using WebShop.Services.Models.Product;
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

        [HttpGet]
        public IActionResult All()
        {
            var data = _service.GetAll();
            var products = new List<ProductShortViewModel>();

            foreach (var dataModel in data)
            {
                products.Add(_mapper.Map<ProductShortViewModel>(dataModel));
            }

            return View(products);
        }

        [HttpPost]
        
        public async Task<IActionResult> All(IFormCollection data)
        {
            var guid = data["item.Id"];
            var id = Guid.Parse(guid);
            var productData = await this._service.GetById(id);
            var product = _mapper.Map<ViewItemViewModel>(productData);
            return RedirectToAction("ViewItem", product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add new product";
            var model = new AddProductViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var newProduct = _mapper.Map<AddProductDto>(product);
            await _service.Add(newProduct);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult ViewItem(ViewItemViewModel item)
        {
            ViewData["Title"] = $"View {item.ProductName}";
            return View(item);
        }
        
    }
}
