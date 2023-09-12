using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static WebShop.Core.Utilities.Validation.AccountUserConstants;

namespace WebShop.Core.Data.Models.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(FirstNameMaxLength)]
        [Comment("User first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength)]
        [Comment("User last name")]
        public string LastName { get; set; } = null!;


        [Required]
        [Comment("Flag for deletion")]
        public bool IsActive { get; set; }
    }
}
