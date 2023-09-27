using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class BasketItemRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        public required string PictureUrl { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        public required string Type { get; set; }
    }
}