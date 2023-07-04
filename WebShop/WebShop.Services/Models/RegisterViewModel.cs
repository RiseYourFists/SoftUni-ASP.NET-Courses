using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static WebShop.Services.Utilities.GlobalVariables;

namespace WebShop.Services.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(AttributeValidations.AccountUser.FirstNameMinLength)]
        [MaxLength(AttributeValidations.AccountUser.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(AttributeValidations.AccountUser.LastNameMinLength)]
        [MaxLength(AttributeValidations.AccountUser.FirstNameMaxLength)]
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

    }
}
