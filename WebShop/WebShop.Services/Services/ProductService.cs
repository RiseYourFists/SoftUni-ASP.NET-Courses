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

        /// <summary>
        /// Adds new brand to Brands table.
        /// </summary>
        /// <param name="model">Template model</param>
        /// <returns>Task</returns>
        public async Task AddBrand(AddBrandModel model)
        {
            var brand = mapper.Map<Brand>(model);

            await repo.AddAsync(brand);

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Adds new category to Categories table.
        /// </summary>
        /// <param name="model">Template model</param>
        /// <returns>Task</returns>
        public async Task AddCategory(AddCategoryModel model)
        {
            var category = mapper.Map<Category>(model);

            await repo.AddAsync(category);

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Adds new product to Products table.
        /// </summary>
        /// <param name="model">Template model</param>
        /// <returns>Task</returns>
        public async Task AddProduct(AddProductModel model)
        {
            model.PromotionalPrice = model.Price;
            var product = mapper.Map<Product>(model);

            await repo.AddAsync(product);

            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all brands from Brands table.
        /// </summary>
        /// <returns>Task&lt;List&lt;BrandListModel&gt;&gt;</returns>
        public async Task<List<BrandListModel>> AllBrands()
        {
            return await repo
                .AllReadonly<Brand>()
                .Where(b => !b.IsDeleted)
                .ProjectTo<BrandListModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all categories from Categories table.
        /// </summary>
        /// <returns>Task&lt;List&lt;CategoryListModel&gt;&gt;</returns>
        public async Task<List<CategoryListModel>> AllCategories()
        {
            return await repo
                .AllReadonly<Category>()
                .Where(c => !c.IsDeleted)
                .ProjectTo<CategoryListModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all products from Product table.
        /// </summary>
        /// <param name="categoryId">Specifies from which category to be pulled.</param>
        /// <param name="searchTerm">Checks for a containing word in the Name or the Brand of the product.</param>
        /// <param name="orderBy">
        /// Orders the products by:
        ///     PriceAsc: Price ascending.
        ///     PriceDesc: Price descending.
        ///     Default: Ordered by product's name.
        /// </param>
        /// <param name="itemsPerPage">Defines how many items to be fetched in one page. Default = 12</param>
        /// <param name="currPage">The new current page. Default = 1</param>
        /// <returns>Task&lt;List&lt;ProductCardViewModel&gt;&gt;</returns>
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
                products = products.Where(p => p.CategoryId == categoryId && !p.IsDeleted);
            }

            if (searchTerm != null)
            {
                var term = searchTerm.ToLower();
                products = products
                    .Where(p => !p.IsDeleted)
                    .Where(p
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

        /// <summary>
        /// Gets the count of all fetched products.
        /// </summary>
        /// <param name="categoryId">Specifies from which category to be pulled.</param>
        /// <param name="searchTerm">Checks for a containing word in the Name or the Brand of the product.</param>
        /// <returns>Task&lt;int&gt;</returns>
        public async Task<int> FilteredProductsCount(
            int? categoryId,
            string? searchTerm)
        {
            var products = repo.AllReadonly<Product>();

            if (categoryId != null && categoryId != -1)
            {
                products = products.Where(p => p.CategoryId == categoryId && !p.IsDeleted);
            }

            if (searchTerm != null)
            {
                var term = searchTerm.ToLower();
                products = products
                    .Where(p => !p.IsDeleted)
                    .Where(p
                    => EF.Functions.Like(p.Name.ToLower(), term)
                    || EF.Functions.Like(p.Brand.Name.ToLower(), term));
            }

            return await products.CountAsync();
        }

        /// <summary>
        /// Checks if a brand exists in Brands table.
        /// </summary>
        /// <param name="brandId">Unique key identifier.</param>
        /// <returns>Task&lt;bool&gt;</returns>
        public async Task<bool> BrandExist(int brandId)
        {
            return await repo
                .AllReadonly<Brand>()
                .AnyAsync(b => b.Id == brandId && b.IsDeleted);
        }

        /// <summary>
        ///  Checks if a category exists in Categories table.
        /// </summary>
        /// <param name="categoryId">Unique key identifier.</param>
        /// <returns>Task&lt;bool&gt;</returns>
        public async Task<bool> CategoryExist(int categoryId)
        {
            return await repo
                .AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId && !c.IsDeleted);
        }

        /// <summary>
        /// Gets a poly list that contains 3 types (BrandPolyItem, CategoryPolyItem, ProductsPolyCollection).
        /// </summary>
        /// <param name="type">
        ///     Enum of 3 types:
        ///         Brands: Gets a polymorphic collection of Brands.
        ///         Categories: Gets a polymorphic collection of Categories.
        ///         Products:  Gets a polymorphic collection of Products.
        /// </param>
        /// <returns>Task&lt;PolyListCollection&gt;</returns>
        public async Task<PolyListCollection> GetPolyList(ManageCategory type)
        {
            var polyObject = new PolyListCollection();

            if (type == ManageCategory.Brands)
            {
                polyObject.Collection.AddRange(await repo
                    .AllReadonly<Brand>()
                    .Where(b => !b.IsDeleted)
                    .ProjectTo<BrandPolyItem>(mapper.ConfigurationProvider)
                    .ToListAsync());

                polyObject.Type = typeof(BrandPolyItem);
            }
            else if (type == ManageCategory.Categories)
            {
                polyObject.Collection.AddRange(await repo
                    .AllReadonly<Category>()
                    .Where(c => !c.IsDeleted)
                    .ProjectTo<CategoryPolyItem>(mapper.ConfigurationProvider)
                    .ToListAsync());

                polyObject.Type = typeof(CategoryPolyItem);
            }
            else
            {
                polyObject.Collection.AddRange(await repo
                    .AllReadonly<Product>()
                    .Where(p => !p.IsDeleted)
                    .ProjectTo<ProductsPolyCollection>(mapper.ConfigurationProvider)
                    .ToListAsync());

                polyObject.Type = typeof(ProductsPolyCollection);
            }

            return polyObject;
        }

        /// <summary>
        /// Gets a product by its id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Task&lt;ViewProductModel&gt;</returns>
        public async Task<ViewProductModel> GetProduct(Guid id)
        {
            var product = await repo.AllReadonly<Product>()
                .Where(p => p.Id == id && !p.IsDeleted)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ProjectTo<ViewProductModel>(mapper.ConfigurationProvider)
                .FirstAsync();

            return product;
        }

        /// <summary>
        /// Checks if product exists.
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Task&lt;bool&gt;</returns>
        public async Task<bool> DoesProductExist(Guid id)
        {
            return await repo.AllReadonly<Product>()
                .AnyAsync(p => p.Id == id);
        }

        /// <summary>
        /// Gets an existing product from Products table.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <returns>Task&lt;EditProductModel&gt;</returns>
        public async Task<EditProductModel> GetEditProduct(Guid id)
        {
            var product = await repo
                .All<Product>()
                .Where(p => p.Id == id && !p.IsDeleted)
                .ProjectTo<EditProductModel>(mapper.ConfigurationProvider)
                .FirstAsync();

            product.Brands = await repo
                .AllReadonly<Brand>()
                .Where(b => !b.IsDeleted)
                .ProjectTo<BrandListModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            product.Categories = await repo
                .AllReadonly<Category>()
                .Where(c => !c.IsDeleted)
                .ProjectTo<CategoryListModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return product;
        }

        /// <summary>
        /// Changes the properties of an existing product.
        /// </summary>
        /// <param name="model">Template model.</param>
        /// <returns>Task</returns>
        public async Task PostEditProduct(EditProductModel model)
        {
            var product = await repo.GetByIdAsync<Product>(model.Id);

            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.PromotionalPrice = model.PromotionalPrice;
            product.ProductImage = model.ProductImage;

            repo.Update(product);
            await repo.SaveChangesAsync();
        }
    }
}
