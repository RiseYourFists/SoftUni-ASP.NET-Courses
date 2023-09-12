using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebShop.Core.Utilities.GlobalVariables;
using static WebShop.Core.Utilities.Validation.AccountUserConstants;

namespace WebShop.Services.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(FirstNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(LastNameMinLength)]
        [MaxLength(FirstNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ErrorMessages.Passwords.NotMatchingPassword)]
        public string RetypePassword { get; set; } = null!;

        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string UserName { get; set; } = null!;

    }
}
