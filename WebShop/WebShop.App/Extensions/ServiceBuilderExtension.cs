using Microsoft.EntityFrameworkCore;
using WebShop.Core.Data;

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
            builder.AddAutoMapper(typeof(Program));

            /*Custom services*/
            builder.AddScoped<DbContext, ApplicationDbContext>();

            return builder;
        }
    }
}
