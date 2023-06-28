using System.ComponentModel.DataAnnotations;

namespace WebShop.App.Models
{
    public class IdData
    {
        [Required]
        public Guid Id { get; set; }
    }
}
