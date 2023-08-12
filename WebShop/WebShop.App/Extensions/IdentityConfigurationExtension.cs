using Microsoft.AspNetCore.Identity;

namespace WebShop.App.Extensions
{
    public static class IdentityConfigurationExtension
    {
        public static IdentityOptions AddOptions(this IdentityOptions options)
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;

            return options;
        }
    }
}
