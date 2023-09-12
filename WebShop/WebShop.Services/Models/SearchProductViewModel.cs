using WebShop.Services.Enums;
using WebShop.Services.Models.ProductModels;

namespace WebShop.Services.Models
{
    public class SearchProductViewModel
    {
        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public ProductOrder OrderBy { get; set; }

        public string? SearchTerm { get; set; }

        public int? CategoryId { get; set; }

        public int ProductCount { get; set; }

        public IList<ProductCardViewModel> Products { get; set; } = new List<ProductCardViewModel>();

        public IList<CategoryListModel> Categories { get; set; } = new List<CategoryListModel>();
    }
}
