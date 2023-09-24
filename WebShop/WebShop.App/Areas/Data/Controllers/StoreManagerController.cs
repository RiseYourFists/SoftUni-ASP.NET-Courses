using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Utilities.GlobalVariables;
using WebShop.Services.Contracts;
using WebShop.Services.Enums;
using WebShop.Services.Models;
using WebShop.Services.Models.ProductModels;

namespace WebShop.App.Areas.Data.Controllers
{
    [Authorize]
    [Area(nameof(Data))]
    //TODO: Add access restrictions.
    public class StoreManagerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService service;
        public StoreManagerController(IMapper _mapper, IProductService _service)
        {
            mapper = _mapper;
            service = _service;
        }

        public async Task<IActionResult> Index(ManageCategory category = ManageCategory.Products)
        {
            var model = await service.GetPolyList(category);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var model = new AddProductModel();

            model.Categories = await service.AllCategories();
            model.Brands = await service.AllBrands();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductModel model)
        {
            var isBrandExist = await service.BrandExist(model.BrandId);
            var isCategoryExist = await service.CategoryExist(model.CategoryId);

            if (!isCategoryExist)
            {
                ModelState.AddModelError(nameof(model.CategoryId), ErrorMessages.CategoryNotFound);
            }

            if (!isBrandExist)
            {
                ModelState.AddModelError(nameof(model.BrandId), ErrorMessages.BrandNotFound);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddProduct(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new AddCategoryModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddCategory(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            var model = new AddBrandModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(AddBrandModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddBrand(model);

            return RedirectToAction("Index");
        }
    }
}
