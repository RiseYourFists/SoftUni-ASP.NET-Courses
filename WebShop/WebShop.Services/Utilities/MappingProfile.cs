using AutoMapper;
using WebShop.Core.Data.Models.WebShopModels;
using WebShop.Services.Models;
using WebShop.Services.Models.PolymorphicCollections;
using WebShop.Services.Models.ProductModels;

namespace WebShop.Services.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryListModel>();
            this.CreateMap<Brand, BrandListModel>();
            this.CreateMap<AddProductModel, Product>();
            this.CreateMap<Category, CategoryPolyItem>();
            this.CreateMap<Brand, BrandPolyItem>();

            this.CreateMap<Product, ViewProductModel>()
                .ForMember(dest =>
                    dest.Brand, opt =>
                    opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest =>
                    dest.Category, opt =>
                    opt.MapFrom(src => src.Category.Name));

            this.CreateMap<Product, ProductCardViewModel>()
                .ForMember(dest => 
                    dest.Brand, opt =>
                    opt.MapFrom(src => src.Brand.Name));

            this.CreateMap<AddCategoryModel, Category>()
                .ForMember(dest => 
                    dest.CategoryBannerImg,opt => 
                    opt.MapFrom(src => src.CategoryImage));

            this.CreateMap<AddBrandModel, Brand>()
                .ForMember(dest => 
                    dest.BrandLogoImg, opt =>
                    opt.MapFrom(src => src.BrandLogoImgUrl));

            this.CreateMap<Product, ProductsPolyCollection>()
                .ForMember(dest => 
                    dest.CurrentPrice, opt => 
                    opt.MapFrom(src => src.PromotionalPrice))
                .ForMember(dest =>
                    dest.BrandName, opt =>
                    opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => 
                    dest.CategoryName, opt => 
                    opt.MapFrom(src => src.Category.Name));

        }
    }
}
