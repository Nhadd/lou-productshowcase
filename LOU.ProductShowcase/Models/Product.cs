using System.ComponentModel.DataAnnotations;

namespace LOU.ProductShowcase.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Range(0, 999999, ErrorMessage = "Price must be between 0 and 999999.")]
        [Display(Name = "Price (₱)")]
        public decimal Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Stock must be between 0 and 10000.")]
        [Display(Name = "Available Stock")]
        public int Stock { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Visible in Public")]
        public bool IsActive { get; set; } = true;

        public string Category { get; set; } = string.Empty;
    }
}
