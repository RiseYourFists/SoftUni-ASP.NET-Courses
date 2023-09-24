using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Contracts;
using WebShop.Core.Data.Models.WebShopModels;
using WebShop.Services.Contracts;
using WebShop.Services.Enums;
using WebShop.Services.Models;
using WebShop.Services.Models.PolymorphicCollections;
using WebShop.Services.Models.ProductModels;

namespace WebShop.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IRepository repo;
        public ProductService(IMapper _mapper, IRepository _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        public async Task AddBrand(AddBrandModel model)
        {
            var brand = mapper.Map<Brand>(model);

            await repo.AddAsync(brand);

            await repo.SaveChangesAsync();
        }

        public async Task AddCategory(AddCategoryModel model)
        {
            var category = mapper.Map<Category>(model);

            await repo.AddAsync(category);

            await repo.SaveChangesAsync();
        }

        public async Task AddProduct(AddProductModel model)
        {
            model.PromotionalPrice = model.Price;
            var product = mapper.Map<Product>(model);

            await repo.AddAsync(product);

            await repo.SaveChangesAsync();
        }

        public async Task<List<BrandListModel>> AllBrands()
        {
            return await repo
                .AllReadonly<Brand>()
                .ProjectTo<BrandListModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<CategoryListModel>> AllCategories()
        {
            return await repo
                .AllReadonly<Category>()
                .ProjectTo<CategoryListModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ProductCardViewModel>> AllProducts(
            int? categoryId,
            string? searchTerm,
            ProductOrder orderBy,
            int itemsPerPage = 12,
            int currPage = 1
            )
        {
            var products = repo.AllReadonly<Product>();


            if (categoryId != null && categoryId != -1)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            if (searchTerm != null)
            {
                var term = searchTerm.ToLower();
                products = products.Where(p
                    => EF.Functions.Like(p.Name.ToLower(), term)
                    || EF.Functions.Like(p.Brand.Name.ToLower(), term));
            }

            products = orderBy switch
            {
                ProductOrder.PriceAsc => products.OrderBy(p => p.Price),
                ProductOrder.PriceDesc => products.OrderByDescending(p => p.Price),
                _ => products.OrderBy(p => p.Name)
            };

            if (currPage < 1)
            {
                currPage = 1;
            }


            var skipCount = itemsPerPage * (currPage - 1);

            products = products
                .Skip(skipCount)
                .Take(itemsPerPage);


            return await products
                .ProjectTo<ProductCardViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<int> FilteredProductsCount(
            int? categoryId,
            string? searchTerm)
        {
            var products = repo.AllReadonly<Product>();

            if (categoryId != null && categoryId != -1)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            if (searchTerm != null)
            {
                var term = searchTerm.ToLower();
                products = products.Where(p
                    => EF.Functions.Like(p.Name.ToLower(), term)
                       || EF.Functions.Like(p.Brand.Name.ToLower(), term));
            }

            return await products.CountAsync();
        }


        public async Task<bool> BrandExist(int brandId)
        {
            return await repo.AllReadonly<Brand>().AnyAsync(b => b.Id == brandId);
        }

        public async Task<bool> CategoryExist(int categoryId)
        {
            return await repo.AllReadonly<Category>().AnyAsync(c => c.Id == categoryId);
        }

        public async Task<PolyListCollection> GetPolyList(ManageCategory type)
        {
            var polyObject = new PolyListCollection();

            switch (type)
            {

                case ManageCategory.Brands:
                    polyObject.Collection
                        .AddRange(await repo
                             .AllReadonly<Brand>()
                             .ProjectTo<BrandPolyItem>(mapper.ConfigurationProvider)
                             .ToListAsync());

                    polyObject.Type = typeof(BrandPolyItem);
                    break;
                case ManageCategory.Categories: 
                    polyObject.Collection
                        .AddRange(await repo
                            .AllReadonly<Category>()
                            .ProjectTo<CategoryPolyItem>(mapper.ConfigurationProvider)
                            .ToListAsync());

                    polyObject.Type = typeof(CategoryPolyItem);
                    break;
                default:
                    polyObject.Collection
                        .AddRange(await repo
                            .AllReadonly<Product>()
                            .ProjectTo<ProductsPolyCollection>(mapper.ConfigurationProvider)
                            .ToListAsync());

                    polyObject.Type = typeof(ProductsPolyCollection);
                    break;
            }


            return polyObject;
        }
    }
}
