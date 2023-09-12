using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Core.Data.Models.WebShopModels;
using WebShop.Services.Models;
using WebShop.Services.Models.ProductModels;

namespace WebShop.Services.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryListModel>();
            this.CreateMap<Brand, BrandListModel>();
            this.CreateMap<Product, ProductCardViewModel>()
                .ForMember(dest => dest.Brand, opt =>
                    opt.MapFrom(src => 
                        src.Brand.Name));
            this.CreateMap<AddProductModel, Product>();
            this.CreateMap<AddCategoryModel, Category>().ForMember(dest => dest.CategoryBannerImg,
                opt => 
                    opt.MapFrom(src => src.CategoryImage));
            this.CreateMap<AddBrandModel, Brand>()
                .ForMember(dest => dest.BrandLogoImg, opt =>
                    opt.MapFrom(src => src.BrandLogoImgUrl));
        }
    }
}
