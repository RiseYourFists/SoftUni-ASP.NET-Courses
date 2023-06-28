using AutoMapper;
using WebShop.App.Models;
using WebShop.Core.Models;
using WebShop.Services.Models.Product;

namespace WebShop.App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<AddProductDto, Product>();
            this.CreateMap<Product, ListProductDto>();
            this.CreateMap<Product, ProductInfoDto>();

            this.CreateMap<ListProductDto, ProductShortViewModel>();
            this.CreateMap<AddProductViewModel, AddProductDto>();

            this.CreateMap<ProductInfoDto, ViewItemViewModel>();
            this.CreateMap<Product, ProductInfoDto>();
        }
    }
}
