using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Contracts;
using WebShop.Core.Data;
using WebShop.Core.Repository;
using WebShop.Services.Contracts;
using WebShop.Services.Services;
using WebShop.Services.Utilities;

namespace WebShop.App.Extensions
{
    public static class ServiceBuilderExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection builder)
        {
            /*Application services*/
            builder.AddRazorPages();
            builder.AddControllersWithViews();
            builder.AddAntiforgery();
            builder.AddCors();

            /*3-rd party services*/
            builder.AddAutoMapper(typeof(MappingProfile));
            builder.AddScoped<IHtmlSanitizer, HtmlSanitizer>();

            /*Custom services*/
            builder.AddScoped<DbContext, ApplicationDbContext>();
            builder.AddScoped<IRepository, Repository>();
            builder.AddScoped<IProductService, ProductService>();

            return builder;
        }
    }
}
