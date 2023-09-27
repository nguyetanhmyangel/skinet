using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CustomerBasketRequest
    {
        [Required]
        public required string Id { get; set; }
        public List<BasketItemRequest>? Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}