using System.ComponentModel.DataAnnotations;

namespace CookieManager.WebAPI.DTO
{
    public class UpdateCookieRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }
        public string? CookieImageUrl { get; set; }
    }
}
