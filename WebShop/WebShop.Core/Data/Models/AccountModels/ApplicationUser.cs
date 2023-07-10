using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static WebShop.Services.Utilities.GlobalVariables.AttributeValidations;

namespace WebShop.Core.Data.Models.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(AccountUser.FirstNameMaxLength)]
        [Comment("User first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(AccountUser.LastNameMaxLength)]
        [Comment("User last name")]
        public string LastName { get; set; } = null!;


        [Required]
        [Comment("Flag for deletion")]
        public bool IsActive { get; set; }
    }
}
