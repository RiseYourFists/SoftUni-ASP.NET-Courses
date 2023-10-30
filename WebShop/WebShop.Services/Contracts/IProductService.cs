using WebShop.Services.Enums;
using WebShop.Services.Models;
using WebShop.Services.Models.PolymorphicCollections;
using WebShop.Services.Models.ProductModels;

namespace WebShop.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductCardViewModel>> AllProducts(
            int? categoryId,
            string? searchTerm,
            ProductOrder orderBy,
            int itemsPerPage,
            int currPage
        );

       Task<List<CategoryListModel>> AllCategories();

       Task<List<BrandListModel>> AllBrands();

        Task AddCategory(AddCategoryModel model);

        Task AddBrand(AddBrandModel model);

        Task AddProduct(AddProductModel model);

        Task<int> FilteredProductsCount(int? categoryId, string? searchTerm);

        Task<bool> CategoryExist(int categoryId);

        Task<bool> BrandExist(int brandId);

        Task<PolyListCollection> GetPolyList(ManageCategory type);

        Task<ViewProductModel> GetProduct(Guid id);

        Task<bool> DoesProductExist(Guid id);

    }
}
